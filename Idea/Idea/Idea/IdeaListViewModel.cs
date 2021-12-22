using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Idea
{
    internal class IdeaListViewModel
    {

        public ObservableCollection<IdeaItem> IdeaItems { get; set; }

        public IdeaListViewModel()
        {
            IdeaItems = new ObservableCollection<IdeaItem>();

            getIdeas();
        }


        public ICommand AddIdeaCommand => new Command(AddIdeaItem);
        public string newIdea {get; set;}
        async void getIdeas()
        {
            var httpClient = new HttpClient();
            

            var resultJson = await httpClient.GetStringAsync("http://192.168.0.206:5168/api/idea");

            var resultIdeas = JsonConvert.DeserializeObject<ObservableCollection<IdeaItem>>(resultJson);

            Console.WriteLine(resultIdeas[0].ideaText);
            IdeaItems.Clear();
            foreach(var item in resultIdeas)
            {
                IdeaItems.Add(item);
            }
        }
        async void AddIdeaItem() 
        {
            var httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            form.Add(new StringContent(newIdea), "IdeaText");
            form.Add(new StringContent("0"), "upVote");
            form.Add(new StringContent("0"), "downVote");

            var response = await httpClient.PostAsync("http://192.168.0.206:5168/api/idea", form);
            getIdeas();
        }

        public ICommand UpCommand => new Command(Up);

        async void Up(object o) 
        {
            IdeaItem ideaUpVote = o as IdeaItem;
            var httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            Console.WriteLine(ideaUpVote.id);

            form.Add(new StringContent(ideaUpVote.id), "id");
            form.Add(new StringContent(ideaUpVote.ideaText), "IdeaText");
            form.Add(new StringContent((ideaUpVote.upVote + 1).ToString()), "upVote");
            form.Add(new StringContent(ideaUpVote.downVote.ToString()), "downVote");

            var response = await httpClient.PutAsync("http://192.168.0.206:5168/api/idea", form);

            getIdeas();

        }

    }
}
