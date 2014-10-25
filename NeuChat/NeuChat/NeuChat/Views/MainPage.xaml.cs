using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuChat.Views {
    public partial class MainPage {
        public MainPage() {
            InitializeComponent();

            // Set view model
            BindingContext = App.Locator.Main;
        }
    }
}
