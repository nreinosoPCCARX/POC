using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.Interfaces;

namespace WebEx.DbContextScope
{
    public class DbContextScope : IDbContextScope
    {
        static readonly string AmbientDbContextScopeKey = $"AmbientDbContext_{Guid.NewGuid()}";
        static readonly ConditionalWeakTable<InstanceIdentifier, DbContextScope> DbContextScopeInstances = new ConditionalWeakTable<InstanceIdentifier, DbContextScope>();
        InstanceIdentifier _instanceIdentifier = new InstanceIdentifier();
        DbContextScope _parentScope;
        bool _disposed;
        bool _completed;
        bool _nested;

        public IDbContextCollection DbContexts { get; private set; }

        public ISession Session { get; private set; }

        public DbContextScope(ISession session, IRepositoryFactory factory)
        {
            _disposed = false;
            _completed = false;
            Session = session;

            _parentScope = GetAmbientScope();
            if(_parentScope != null)
            {
                _nested = true;
                DbContexts = _parentScope.DbContexts;
            }
            else
            {
                _nested = false;
                DbContexts = new DbContextCollection(Session, factory);
            }

            SetAmbientScope(this);
        }

        public void Dispose()
        {
            if(_disposed) { return; }

            if (!_nested)
            {
                if (!_completed)
                {
                    SaveChanges();
                }

                DbContexts.Dispose(); 
            }

            RemoveAmbientScope();

            if (_parentScope != null)
            {
                if (!_parentScope._disposed)
                {
                    SetAmbientScope(_parentScope);
                }
            }

            _disposed = true;
        }

        public int SaveChanges()
        {
            if (_disposed) { throw new ObjectDisposedException(nameof(DbContextScope)); }

            if(_completed) { throw new Exception("Cannot call SaveChanges() more than once."); }

            var committed = 0;

            if(!_nested)
            {
                DbContexts.Commit();
            }

            _completed = true;

            return committed;
        }

        internal static void SetAmbientScope(DbContextScope newAmbientScope)
        {
            if(newAmbientScope == null) { throw new ArgumentNullException("newAmbientScope"); }

            var current = CallContext.LogicalGetData(AmbientDbContextScopeKey) as InstanceIdentifier;

            if(current == null)
            {
                CallContext.LogicalSetData(AmbientDbContextScopeKey, newAmbientScope._instanceIdentifier);
                DbContextScopeInstances.Add(newAmbientScope._instanceIdentifier, newAmbientScope);
            }
        }

        internal static DbContextScope GetAmbientScope()
        {
            var instance = CallContext.LogicalGetData(AmbientDbContextScopeKey) as InstanceIdentifier;

            if (instance != null)
            {
                DbContextScope scope;
                if (DbContextScopeInstances.TryGetValue(instance, out scope))
                {
                    return scope;
                }
            }

            return null;
        }

        internal static void RemoveAmbientScope()
        {
            var current = CallContext.LogicalGetData(AmbientDbContextScopeKey) as InstanceIdentifier;
            CallContext.LogicalSetData(AmbientDbContextScopeKey, null);

            if(current != null)
            {
                DbContextScopeInstances.Remove(current);
            }
        }
    }

    class InstanceIdentifier : MarshalByRefObject { }
}
