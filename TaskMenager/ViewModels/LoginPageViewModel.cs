using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Engines;
using TaskMenager.Models;

namespace TaskMenager.ViewModels
{
    internal class LoginPageViewModel : INotifyPropertyChanged
    {
        private MongoEngine _mongoEngine { get; set; }

        public User SampleUser { get; set; }

        private string _sampleText;

        public string SampleText
        {
            get { return _sampleText; }
            set { _sampleText = value; OnPropertyChanged(); }
        }


        public LoginPageViewModel()
        {
            _mongoEngine = new MongoEngine("AddressBook");
            SampleUser = test();
            SampleText = SampleUser.Password;
        }

        private User test()
        {
            bool IsUserExisting = _mongoEngine.FindRecordToLogin<User>("Users", "Stachu", "Jones");
            User user = _mongoEngine.LoadRecordByLogin<User>("Users", "Stachu");
            return user;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
