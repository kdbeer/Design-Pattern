using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Document[] documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();

            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }

            }

            //Wait for user key
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Page' class
    /// </summary>
    abstract class Page
    {

    }

    /// <summary>
    /// The 'SkillPage' class
    /// </summary>
    class SkillPage : Page
    {

    }

    /// <summary>
    /// The 'EducationPage' class
    /// </summary>
    class EducationPage : Page
    {

    }

    /// <summary>
    /// The 'ExperiencePage' classs
    /// </summary>
    class ExperiencePage : Page
    {

    }

    /// <summary>
    /// The 'IntoductionPage' class
    /// </summary>
    class IntroductionPage : Page
    {

    }

    /// <summary>
    /// The 'ResultPage' class
    /// </summary>
    class ResultPage : Page
    {

    }

    /// <summary>
    /// The 'ConclusionPage' class
    /// </summary>
    class ConclusionPage : Page
    {

    }

    /// <summary>
    /// The 'SummaryPage' class
    /// </summary>
    class SummaryPage : Page
    {

    }

    /// <summary>
    /// The 'BibliographyPage' class
    /// </summary>
    class BibliographyPage : Page
    {

    }

    abstract class Document
    {
        private List<Page> _pages = new List<Page>();

        // Constructor calls abstract Factory method
        public Document()
        {
            this.CreatePages();
        }

        public List<Page> Pages
        {
            get { return _pages; }
        }

        public abstract void CreatePages();
    }

    class Resume : Document
    {
        //Factory Implementation
        public override void CreatePages()
        {
            Pages.Add(new SkillPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }

    class Report : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }
}
