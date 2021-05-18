using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;

namespace AutoFramework.Scenarios
{
    public class SearchPageTest
    {
       
       

        [SetUp]
        public void Initialize()
        {
            Actions.InitializeDriver();
            Driver.driver.Navigate().GoToUrl(Config.BaseURL);

        }

        [Test]
        public void IsSearchButtonAndQueryInputVisible()
        {
            AutoFramework.Pages.PageElements.Page _page = new Pages.PageElements.Page();
            Assert.IsTrue(_page.SearchButton.Displayed);
            Assert.IsTrue(_page.SearchInput.Displayed);
        }
        
        [Test]
        public void IsEmptyQueryForbidden()
        {
            AutoFramework.Pages.PageElements.Page _page = new Pages.PageElements.Page();
            _page.SearchButton.Click();
            Assert.IsTrue(_page.ErrorEmptyQuery.Displayed);
            Assert.AreEqual(_page.ErrorEmptyQuery.GetAttribute("innerHTML"), "Provide some query");
        }

        [Test]
        public void IsOneIslandReturning()
        {
            AutoFramework.Pages.PageElements.Page _page = new Pages.PageElements.Page();
            _page.SearchInput.Clear();
            _page.SearchInput.SendKeys("isla");
            _page.SearchButton.Click();
            IReadOnlyCollection<IWebElement> _list = Driver.driver.FindElements(By.XPath("//*[@id='search-results']"));
            Assert.IsTrue(_list.Count > 0);
        }

        [Test]
        public void IsNoResultFeedback()
        {
            AutoFramework.Pages.PageElements.Page _page = new Pages.PageElements.Page();
            _page.SearchInput.Clear();
            _page.SearchInput.SendKeys("castle");
            _page.SearchButton.Click(); Assert.IsTrue(_page.NoResultsLabel.Displayed);
            Assert.AreEqual(_page.NoResultsLabel.GetAttribute("innerHTML"), "No results"); ;
        }

        

        [TearDown]
        public void CleanUp()
        {
            Driver.driver.Quit();
        }
    }
}
