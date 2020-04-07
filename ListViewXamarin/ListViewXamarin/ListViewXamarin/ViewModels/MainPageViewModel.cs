using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ListViewXamarin
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private ObservableCollection<ToDoItem> toDoList;

        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            this.GenerateSource();
            ItemDraggingCommand = new DelegateCommand<ItemDraggingEventArgs>(OnItemDragging);
        }

        #endregion

        #region Properties

        public DelegateCommand<ItemDraggingEventArgs> ItemDraggingCommand { get; set; }

        public ObservableCollection<ToDoItem> ToDoList
        {
            get
            {
                return toDoList;
            }
            set
            {
                this.toDoList = value;
            }
        }
        #endregion

        #region Methods

        public void GenerateSource()
        {
            ToDoListRepository todoRepository = new ToDoListRepository();
            toDoList = todoRepository.GetToDoList();
        }

        private void OnItemDragging(ItemDraggingEventArgs args)
        {
            if (args.Action == DragAction.Drop)
                App.Current.MainPage.DisplayAlert("Message", "ListView item index after reordering " + args.NewIndex, "Ok");
        }
        #endregion

        #region Prism Methods

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        #endregion
    }
}
