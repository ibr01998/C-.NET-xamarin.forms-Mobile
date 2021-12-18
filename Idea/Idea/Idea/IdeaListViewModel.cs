using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Idea
{
    internal class IdeaListViewModel
    {

        public ObservableCollection<IdeaItem> IdeaItems { get; set; }

        public IdeaListViewModel()
        {
            IdeaItems = new ObservableCollection<IdeaItem>();

            IdeaItems.Add(new IdeaItem("idea 1 this is something im writhing down just to see how longer shit look on this app thank you for understanding you dick head", 0, 0));
            IdeaItems.Add(new IdeaItem("idea 2", 10, 3));
            IdeaItems.Add(new IdeaItem("idea 3", 30, 10));
            IdeaItems.Add(new IdeaItem("idea 4", 50, 30));
        }


        public ICommand AddIdeaCommand => new Command(AddIdeaItem);
        public string newIdea {get; set;}
        void AddIdeaItem() 
        {
            IdeaItems.Add(new IdeaItem(newIdea, 0, 0));
        }

        public ICommand UpCommand => new Command(Up);

        void Up(object o) 
        {
            IdeaItem ideaUpVote = o as IdeaItem;
            for(int i = 0; i < IdeaItems.Count; i++)
            {
                if (IdeaItems[i].IdeaText == ideaUpVote.IdeaText)
                {
                    IdeaItems[i].UpVode = IdeaItems[i].UpVode + 1;
                    Console.WriteLine(IdeaItems[i].UpVode);
                    Console.WriteLine(IdeaItems[i].IdeaText);                
                }

            }
            Console.WriteLine(ideaUpVote);
        }
        
    }
}
