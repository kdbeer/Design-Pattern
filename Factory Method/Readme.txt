องค์ประกอบของคลาส

Product  	: (Page)
	=> The class that implements the interface that gives the product what the base class does.		

ConcreteProduct	: (SkillsPage, EducationPage, ExperiencePage)
	=> The extends generally from the Product class, which when extends, adds a special effect to child.

Creator  	: (Document)
	=>Interface class for creating documents.

ConcreteCreator	: (Report, Resume)
	=> Override creator and use concrete product.
------------------------------------------------------------------------------------------------------------------
Pages.Add(new IntroductionPage());
            Pages.Add(new ResultPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());

You can see that we just created a list of creators, which is a parent class, so we can add them. Without creating a child variable

------------------------------------------------------------------------------------------------------------------

Document[] documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();


This is the same as we can create a parent can add child to it.


