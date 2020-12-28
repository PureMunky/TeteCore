using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Tete.Api.Contexts;
using Tete.Api.Services.Content;
using Tete.Models.Content;
using Tete.Models.Relationships;
using Tete.Tests.Setup;

namespace Tete.Tests.Api.Services.Content
{
  public class TopicServiceTests : TestBase
  {
    TopicService service;

    [SetUp]
    public void SetupSettings()
    {
      this.service = new TopicService(mockContext.Object, AdminUserVM);
    }

    private TopicService GetService(Guid ActorUserId)
    {
      var Actor = this.mockContext.Object.Users.Where(u => u.Id == ActorUserId).FirstOrDefault();
      return new TopicService(mockContext.Object, new Tete.Models.Authentication.UserVM(Actor));
    }

    // [Test]
    // public void GetTest()
    // {
    //   var result = this.service.GetTopics();

    //   mockContext.Verify(m => m.Topics, Times.Once);
    // }

    [Test]
    public void SaveTopicTest()
    {
      var newTopic = new TopicVM()
      {
        Name = "New Topic"
      };
      this.service.SaveTopic(newTopic);

      mockContext.Verify(m => m.Topics.Add(It.IsAny<Topic>()), Times.Once);
    }

    [Test]
    public void SaveNewTopicTest()
    {
      var newTopic = new TopicVM()
      {
        TopicId = Guid.Empty,
        Name = "Empty Guid Topic"
      };
      this.service.SaveTopic(newTopic);

      mockContext.Verify(m => m.Topics.Add(It.IsAny<Topic>()), Times.Once);
    }

    [Test]
    public void SaveExistingTest()
    {
      var existingTopic = new TopicVM()
      {
        TopicId = existingTopicId,
        Name = "Existing Topic"
      };
      this.service.SaveTopic(existingTopic);

      mockContext.Verify(m => m.Topics.Update(It.IsAny<Topic>()), Times.Once);
    }

    [Test]
    public void SearchTest()
    {
      var result = this.service.Search("topic");

      var e = result.GetEnumerator();
      e.MoveNext();
      mockContext.Verify(m => m.Topics, Times.Once);
      Assert.IsTrue(e.Current != null);
    }

    [Test]
    public void GetKeywordTopicsTest()
    {
      var result = this.service.GetKeywordTopics(keyword);

      var e = result.GetEnumerator();
      e.MoveNext();
      mockContext.Verify(m => m.Topics, Times.Once);
      Assert.IsTrue(e.Current != null);

      // Commenting because the VM is not fully populated in this method and it isn't required
      // to be for the front-end usage.
      // foreach (TopicVM t in result)
      // {
      //   Assert.IsTrue(t.Keywords.AsQueryable().Where(k => k.Name == keyword).Count() > 0);
      // }
    }

    [Test]
    public void GetUsersTopicsTest()
    {
      var result = this.service.GetUsersTopics(adminUser.Id);

      var e = result.GetEnumerator();
      e.MoveNext();
      mockContext.Verify(m => m.Topics, Times.Once);
      Assert.IsTrue(e.Current != null);
    }

    [Test]
    public void GetTopTopicsTest()
    {
      var result = this.service.GetTopTopics();

      Assert.AreEqual(10, result.Count());
    }

    [Test]
    public void GetNewestTopicsTest()
    {
      var result = this.service.GetNewestTopics();

      Assert.AreEqual(10, result.Count());
    }

    [Test]
    public void GetWaitingTopicsTest()
    {
      var result = this.service.GetWaitingTopics();

      Assert.AreEqual(10, result.Count());
    }

    [Test]
    public void GetKeywordsTests()
    {
      var result = this.service.GetKeywords();

      Assert.AreEqual(3, result.Count());
    }

    [Test]
    public void GetKeywordsTestForNonAdmin()
    {
      var service = GetService(newUserId);
      var result = service.GetKeywords();
      Assert.AreEqual(1, result.Count());
    }

    [Test]
    public void SaveKeywordsTest()
    {
      var keywords = new List<Keyword>() {
        new Keyword() {
          Name = "SaveKeywordsTest"
        }
      };

      this.service.SaveKeywords(keywords, existingTopicId);

      mockContext.Verify(c => c.Keywords.Add(It.IsAny<Keyword>()), Times.Once);
    }

    [Test]
    public void SaveLinksTest()
    {
      var links = new List<Link>() {
        new Link() {
          Destination = "https://tetelearning.com"
        }
      };

      this.service.SaveLinks(links, existingTopicId);

      mockContext.Verify(c => c.Links.Add(It.IsAny<Link>()), Times.Once);
    }

    #region Set User Topic Tests

    private void TestSetUserTopic(Guid ActorUserId, Guid UserId, Guid TopicId, TopicStatus topicStatus, Times AddTimes, Times UpdateTimes)
    {
      var service = GetService(ActorUserId);
      service.SetUserTopic(UserId, TopicId, topicStatus);
      mockContext.Verify(c => c.UserTopics.Add(It.IsAny<UserTopic>()), AddTimes);
      mockContext.Verify(c => c.UserTopics.Update(It.IsAny<UserTopic>()), UpdateTimes);
    }

    #region Elligible Topic Tests

    // New User Tests
    [Test]
    public void SetUserTopicTestElligibleNewNovice()
    {
      TestSetUserTopic(newUserId, newUserId, largeTopicId, TopicStatus.Novice, Times.Once(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestElligibleNewGraduate()
    {
      TestSetUserTopic(newUserId, newUserId, largeTopicId, TopicStatus.Graduate, Times.Never(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestElligibleNewMaster()
    {
      TestSetUserTopic(newUserId, newUserId, largeTopicId, TopicStatus.Master, Times.Never(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestElligibleNewMentor()
    {
      TestSetUserTopic(newUserId, newUserId, largeTopicId, TopicStatus.Mentor, Times.Never(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestElligibleNewDeacon()
    {
      TestSetUserTopic(newUserId, newUserId, largeTopicId, TopicStatus.Deacon, Times.Never(), Times.Never());
    }

    // Novice Tests
    [Test]
    public void SetUserTopicTestElligibleNoviceToNovice()
    {
      TestSetUserTopic(noviceUserId, noviceUserId, largeTopicId, TopicStatus.Novice, Times.Never(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestElligibleNoviceToGraduateBySelf()
    {
      TestSetUserTopic(noviceUserId, noviceUserId, largeTopicId, TopicStatus.Graduate, Times.Never(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestElligibleNoviceToGraduateByMentor()
    {
      TestSetUserTopic(mentorUserId, noviceUserId, largeTopicId, TopicStatus.Graduate, Times.Never(), Times.Once());
    }

    [Test]
    public void SetUserTopicTestElligibleNoviceToGraduateByDeacon()
    {
      TestSetUserTopic(deaconUserId, noviceUserId, largeTopicId, TopicStatus.Graduate, Times.Never(), Times.Once());
    }

    [Test]
    public void SetUserTopicTestElligibleNoviceToMaster()
    {
      TestSetUserTopic(noviceUserId, noviceUserId, largeTopicId, TopicStatus.Master, Times.Never(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestElligibleNoviceToMentor()
    {
      TestSetUserTopic(noviceUserId, noviceUserId, largeTopicId, TopicStatus.Mentor, Times.Never(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestElligibleNoviceToDeacon()
    {
      TestSetUserTopic(noviceUserId, noviceUserId, largeTopicId, TopicStatus.Deacon, Times.Never(), Times.Never());
    }

    // Graduate Tests

    [Test]
    public void SetUserTopicTestElligibleGraduateToNovice()
    {
      TestSetUserTopic(graduateUserId, graduateUserId, largeTopicId, TopicStatus.Novice, Times.Never(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestElligibleGraduateToGraduateBySelf()
    {
      TestSetUserTopic(graduateUserId, graduateUserId, largeTopicId, TopicStatus.Graduate, Times.Never(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestElligibleGraduateToMaster()
    {
      TestSetUserTopic(noviceUserId, graduateUserId, largeTopicId, TopicStatus.Master, Times.Never(), Times.Once());
    }

    [Test]
    public void SetUserTopicTestElligibleGraduateToMentor()
    {
      TestSetUserTopic(mentorUserId, graduateUserId, largeTopicId, TopicStatus.Mentor, Times.Never(), Times.Once());
    }

    [Test]
    public void SetUserTopicTestElligibleGraduateToDeacon()
    {
      TestSetUserTopic(deaconUserId, graduateUserId, largeTopicId, TopicStatus.Deacon, Times.Never(), Times.Never());
    }
    #endregion

    #region Non-Elligible Topic Tests

    [Test]
    public void SetUserTopicTestNonElligibleNewNovice()
    {
      TestSetUserTopic(newUserId, newUserId, existingTopicId, TopicStatus.Novice, Times.Once(), Times.Never());
    }

    [Test]
    public void SetUserTopicTestNonElligibleNewMentor()
    {
      TestSetUserTopic(newUserId, newUserId, existingTopicId, TopicStatus.Mentor, Times.Once(), Times.Never());
    }

    #endregion

    #endregion
  }
}