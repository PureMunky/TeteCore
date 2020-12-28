using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Tete.Api.Helpers;
using Tete.Models.Authentication;
using Tete.Models.Localization;
using Tete.Models.Users;
using Tete.Models.Relationships;
using Tete.Models.Config;
using Tete.Models.Content;

namespace Tete.Tests.Setup
{
  public abstract class TestBase
  {
    protected Mock<Tete.Api.Contexts.MainContext> mockContext;

    protected Guid existingUserId = Guid.NewGuid();

    protected Guid newUserId = Guid.NewGuid();

    protected User adminUser = new User()
    {
      DisplayName = "Administrator",
      UserName = "admin"
    };

    protected Guid noviceUserId = Guid.NewGuid();
    protected Guid graduateUserId = Guid.NewGuid();
    protected Guid masterUserId = Guid.NewGuid();
    protected Guid mentorUserId = Guid.NewGuid();
    protected Guid deaconUserId = Guid.NewGuid();

    protected string settingKey = "settingKey1";

    public UserVM AdminUserVM
    {
      get
      {
        return new UserVM(adminUser)
        {
          Roles = new List<string>() {
            "Admin"
          }
        };
      }
    }

    public Guid linkId = Guid.NewGuid();
    public Guid existingTopicId = Guid.NewGuid();
    public Guid brinkTopicId = Guid.NewGuid();
    public Guid largeTopicId = Guid.NewGuid();

    public string keyword = "existingkeyword";
    public Guid englishId = Guid.NewGuid();
    public Guid spanishId = Guid.NewGuid();

    protected string testLanguageElementKey = "TestKey";
    protected string testLanguageElementText = "TextText";

    public Guid mentorshipId = Guid.NewGuid();

    [SetUp]
    public void Setup()
    {

      User existingUser = new User()
      {
        Id = existingUserId,
        DisplayName = "test user",
        UserName = "TestUser"
      };

      User newUser = new User()
      {
        Id = newUserId
      };

      Language english = new Language()
      {
        LanguageId = englishId,
        Name = "English",
        Active = true
      };

      Language spanish = new Language()
      {
        LanguageId = spanishId,
        Name = "Spanish",
        Active = true
      };

      Element welcome = new Element()
      {
        Key = "welcome",
        Text = "Welcome!",
        LanguageId = english.LanguageId
      };
      Element testElement = new Element() { Key = testLanguageElementKey, Text = testLanguageElementText };

      var userLanguage = new UserLanguage()
      {
        LanguageId = english.LanguageId,
        UserId = existingUserId
      };

      var adminUserLanguage = new UserLanguage()
      {
        LanguageId = spanish.LanguageId,
        UserId = adminUser.Id
      };

      var userProfile = new Profile(existingUserId);

      var accessRoles = new List<AccessRole>() {
        new AccessRole(existingUserId, "Admin") {
          CreatedBy = existingUserId
        },
        new AccessRole(adminUser.Id, "Admin") {
          CreatedBy = adminUser.Id
        }
      };

      var users = new List<User> {
        existingUser,
        adminUser,
        newUser,
        new User() {
          Id = noviceUserId,
          UserName = "novice"
        },
        new User() {
          Id = graduateUserId,
          UserName = "graduate"
        },
        new User() {
          Id = masterUserId,
          UserName = "master"
        },
        new User() {
          Id = mentorUserId,
          UserName = "mentor"
        },
        new User() {
          Id = deaconUserId,
          UserName = "deacon"
        }
      };

      for (int i = 0; i < 35; i++)
      {
        users.Add(new User()
        {
          UserName = "dummy" + i.ToString(),
          DisplayName = "Dummy " + i.ToString()
        });
      }

      IQueryable<UserLanguage> userLanguages = new List<UserLanguage> {
        userLanguage,
        adminUserLanguage
      }.AsQueryable();

      IQueryable<Profile> userProfiles = new List<Profile>() {
        userProfile,
        new Profile(adminUser.Id)
      }.AsQueryable();

      IQueryable<UserBlock> userBlocks = new List<UserBlock>().AsQueryable();

      IQueryable<Language> languages = new List<Language>()
      {
        english,
        spanish
      }.AsQueryable();

      IQueryable<Element> elements = new List<Element>()
      {
        testElement,
        welcome
      }.AsQueryable();

      IQueryable<AccessRole> userAccessRoles = accessRoles.AsQueryable();

      IQueryable<Setting> settings = new List<Setting>()
      {
        new Setting() {
          Key = settingKey,
          Value = Guid.NewGuid().ToString()
        }
      }.AsQueryable();

      IQueryable<Link> links = new List<Link>()
      {
        new Link() {
          LinkId = linkId,
          Name = "Google",
          Destination = "https://www.google.com"
        }
      }.AsQueryable();

      var topics = new List<Topic>()
      {
        new Topic(){
          TopicId = existingTopicId,
          Name = "Existing Topic Name"
        },
        new Topic() {
          TopicId = brinkTopicId,
          Name = "Brink of Elligbility",
          Description = "This topic is budding and on the brink of elligibility."
        },
        new Topic(){
          TopicId = largeTopicId,
          Name = "Large Establised Topic",
          Description = "Lots of things going on in this topic.",
          Elligible = true
        }
      };

      var existingkeyword = new Keyword()
      {
        Name = keyword
      };

      var keywords = new List<Keyword>()
      {
        existingkeyword,
        new Keyword() {
          Name = "Restricted",
          Restricted = true
        },
        new Keyword() {
          Name = "Inactive",
          Active = false
        }
      }.AsQueryable();

      var topicKeywords = new List<TopicKeyword>()
      {
        new TopicKeyword()
        {
          TopicId = existingTopicId,
          KeywordId = existingkeyword.KeywordId
        }
      };

      var topicLinks = new List<TopicLink>()
      {
        new TopicLink()
        {
          TopicId = existingTopicId,
          LinkId = linkId
        }
      };

      var userTopics = new List<UserTopic>()
      {
        new UserTopic(adminUser.Id, existingTopicId, TopicStatus.Mentor),
        new UserTopic(noviceUserId, largeTopicId, TopicStatus.Novice),
        new UserTopic(graduateUserId, largeTopicId, TopicStatus.Graduate),
        new UserTopic(masterUserId, largeTopicId, TopicStatus.Master),
        new UserTopic(mentorUserId, largeTopicId, TopicStatus.Mentor),
        new UserTopic(deaconUserId, largeTopicId, TopicStatus.Deacon)
      };

      foreach (User u in users)
      {
        if (u.UserName != null && u.UserName.StartsWith("dummy"))
        {
          userTopics.Add(new UserTopic(adminUser.Id, largeTopicId, TopicStatus.Mentor));
          userTopics.Add(new UserTopic(adminUser.Id, brinkTopicId, TopicStatus.Mentor));
        }
      }

      var mentorships = new List<Mentorship>()
      {
        new Mentorship(existingUserId, existingTopicId) {
          MentorshipId = mentorshipId
        }
      };

      for (int i = 0; i < 12; i++)
      {
        var t = new Topic()
        {
          Name = Guid.NewGuid().ToString()
        };

        topics.Add(t);
        userTopics.Add(new UserTopic(existingUserId, t.TopicId, TopicStatus.Novice));
        mentorships.Add(new Mentorship(existingUserId, t.TopicId));
      }
      var mockUsers = MockContext.MockDBSet<User>(users);
      var mockUserLanguages = MockContext.MockDBSet<UserLanguage>(userLanguages);
      var mockUserProfiles = MockContext.MockDBSet<Profile>(userProfiles);
      var mockUserBlocks = MockContext.MockDBSet<UserBlock>(userBlocks);
      var mockUserAccessRoles = MockContext.MockDBSet<AccessRole>(userAccessRoles);
      var mockLanguages = MockContext.MockDBSet<Language>(languages);
      var mockElements = MockContext.MockDBSet<Element>(elements);
      var mockUserTopics = MockContext.MockDBSet<UserTopic>(userTopics);
      var mockSettings = MockContext.MockDBSet<Setting>(settings);
      var mockLinks = MockContext.MockDBSet<Link>(links);
      var mockTopics = MockContext.MockDBSet<Topic>(topics);
      var mockTopicLinks = MockContext.MockDBSet<TopicLink>(topicLinks);
      var mockKeywords = MockContext.MockDBSet<Keyword>(keywords);
      var mockTopicKeywords = MockContext.MockDBSet<TopicKeyword>(topicKeywords);

      mockContext = MockContext.GetDefaultContext();
      mockContext.Setup(c => c.Users).Returns(mockUsers.Object);
      mockContext.Setup(c => c.UserLanguages).Returns(mockUserLanguages.Object);
      mockContext.Setup(c => c.UserProfiles).Returns(mockUserProfiles.Object);
      mockContext.Setup(c => c.UserBlocks).Returns(mockUserBlocks.Object);
      mockContext.Setup(c => c.AccessRoles).Returns(mockUserAccessRoles.Object);
      mockContext.Setup(c => c.Languages).Returns(mockLanguages.Object);
      mockContext.Setup(c => c.Elements).Returns(mockElements.Object);
      mockContext.Setup(c => c.UserTopics).Returns(mockUserTopics.Object);
      mockContext.Setup(c => c.Settings).Returns(mockSettings.Object);
      mockContext.Setup(c => c.Links).Returns(mockLinks.Object);
      mockContext.Setup(c => c.Topics).Returns(mockTopics.Object);
      mockContext.Setup(c => c.TopicLinks).Returns(mockTopicLinks.Object);
      mockContext.Setup(c => c.Keywords).Returns(mockKeywords.Object);
      mockContext.Setup(c => c.TopicKeywords).Returns(mockTopicKeywords.Object);

      mockContext.Setup(c => c.Mentorships)
        .Returns(MockContext.MockDBSet<Mentorship>(mentorships).Object);

      mockContext.Setup(c => c.Logins)
        .Returns(MockContext.MockDBSet<Login>().Object);

      mockContext.Setup(c => c.Assessments)
        .Returns(MockContext.MockDBSet<Assessment>().Object);

    }

  }
}