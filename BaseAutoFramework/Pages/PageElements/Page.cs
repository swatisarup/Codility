using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoFramework.Pages.PageElements
{
    public class Page
    {
        public Page()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        [FindsBy(How = How.Id, Using = "search-input")]
        public IWebElement SearchInput { get; set; }

        [FindsBy(How = How.Id, Using = "search-button")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "output-container")]
        public IWebElement ResultLabel { get; set; }

        [FindsBy(How = How.Id, Using = "search-results")]
        public IWebElement SearchResults { get; set; }

        [FindsBy(How = How.Id, Using = "error-no-results")]
        public IWebElement NoResultsLabel { get; set; }

        [FindsBy(How = How.Id, Using = "error-empty-query")]
        public IWebElement ErrorEmptyQuery { get; set; }
    }
}
