using System.Windows.Forms;
using WebEx.Interfaces.Interfaces.Modules;
using WebEx.Person.Interface;

namespace WebEx.Person.UIModule
{
    public class PersonUIModule : IUIModule
    {
        readonly IPersonModule _personModule;

        public PersonUIModule(IPersonModule personModule)
        {
            _personModule = personModule;

            MessageBox.Show("Person UI Loaded with person module!");
        }
    }
}
