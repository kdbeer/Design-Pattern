องค์ประกอบของคลาส

Product  	: (Page)
	=> คลาสที่เอาไว้สสร้าง interface ว่าจะให้ product ซึ่งเป็น base class ทำอะไรได้บ้าง		

ConcreteProduct	: (SkillsPage, EducationPage, ExperiencePage)
	=> การ extends ทั่วๆ ไป จากคลาสของ Product ซึ่งเมื่อ extends มาแล้วก็เพิ่มลักษณะพิเศษเข้าไปให้มัน

Creator  	: (Document)
	=> เป็น Interface class สำหรับสร้าง dicuments

ConcreteCreator	: (Report, Resume)
	=> overide เอา creator มาใช้ แลพเรียกใช้งาน concreate product
------------------------------------------------------------------------------------------------------------------
Pages.Add(new IntroductionPage());
            Pages.Add(new ResultPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());

จะเห็นได้ว่า เราเพียงแค่สร้างลิสต์ของ creator ซึ่งเป็น คลาส แม่ เอาไว้ แล้วเราสามารถ Add ลูกเข้าไปได้เลย โดยที่ไม่ต้องสร้างตัวแปรของลูก

------------------------------------------------------------------------------------------------------------------

Document[] documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();

นี่เหมือนกัน เราสร้างแม่ แล้วสามารถ Add ลูกเข้าไปได้เลย	


