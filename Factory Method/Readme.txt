ͧ���Сͺ�ͧ����

Product  	: (Page)
	=> ���ʷ������������ҧ interface ��Ҩ���� product ����� base class ���������ҧ		

ConcreteProduct	: (SkillsPage, EducationPage, ExperiencePage)
	=> ��� extends ����� � �ҡ���ʢͧ Product �������� extends �����ǡ������ѡɳо������������ѹ

Creator  	: (Document)
	=> �� Interface class ����Ѻ���ҧ dicuments

ConcreteCreator	: (Report, Resume)
	=> overide ��� creator ���� �ž���¡��ҹ concreate product
------------------------------------------------------------------------------------------------------------------
Pages.Add(new IntroductionPage());
            Pages.Add(new ResultPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());

���������� �����§�����ҧ��ʵ�ͧ creator ����� ���� ��� ������ �����������ö Add �١��������� �·������ͧ���ҧ����âͧ�١

------------------------------------------------------------------------------------------------------------------

Document[] documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();

�������͹�ѹ ������ҧ��� ��������ö Add �١���������	


