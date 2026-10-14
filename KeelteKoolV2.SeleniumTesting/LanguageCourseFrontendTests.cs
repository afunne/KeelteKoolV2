using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KeelteKoolV2.SeleniumTesting
{
    public class LanguageCourseFrontendTests
    {
        [Fact]
        public void Should_NavigateToIndex_AddSpaceshipWithCorrectData_ReturnToIndex()
        {
            /* Ülesseade */
            IWebDriver driver = new FirefoxDriver(); //brauserit juhtiv ja seal tegutsev draiver
            driver.Url = "https://localhost:7191/"; //navigeeritav aadress
            Thread.Sleep(3000);
            IWebElement navigateToLanguageCourse = driver.FindElement(By.LinkText("Keelekursused"));//otsime tesitava osa lingi
            navigateToLanguageCourse.Click(); //simuleeritud tegevus elemendiga, antud juhul klikk

            /* tegevus */
            IWebElement indexCreateButton = driver.FindElement(By.Id("IndexCreateNewLanguageCourse_BTN"));
            indexCreateButton.Click();
            IWebElement createEntryNimetus = driver.FindElement(By.Id("CU_LanguageCourse_Nimetus"));
            createEntryNimetus.SendKeys("Automaattestimise kursus");
            IWebElement createEntryKeel = driver.FindElement(By.Id("CU_LanguageCourse_Keel"));
            createEntryKeel.SendKeys("C# + Selenium & xUnit");
            IWebElement createEntryTase = driver.FindElement(By.Id("CU_LanguageCourse_Tase"));
            createEntryTase.SendKeys("3");
            IWebElement createEntryKirjeldus = driver.FindElement(By.Id("CU_LanguageCourse_Kirjeldus"));
            createEntryKirjeldus.SendKeys("Kursusel õpime mis on automaattestimine, kuidas erineb manuaaltestimisest ning kuidas kirjutada " +
                "backendi ja frontendi automaatteste.");
            IWebElement CreateCreateButton = driver.FindElement(By.Id("CU_Create_BTN"));
            CreateCreateButton.Click();

            /* kontroll */

            //kogume andmed kõigist tabeli ridadest, sest uus kursus ei pruugi olla esimene rida
            List<string> LanguageCourseNameData = driver.FindElements(By.Id("IndexTableCourseNimetus")).Select(x => x.Text).ToList();
            List<string> LanguageCourseKeelData = driver.FindElements(By.Id("IndexTableCourseKeel")).Select(x => x.Text).ToList();
            //sulgeme akna
            Thread.Sleep(500);
            driver.Quit();
            //assertime
            Assert.Contains("Automaattestimise kursus", LanguageCourseNameData);
            Assert.Contains("C# + Selenium & xUnit", LanguageCourseKeelData);
        }
    }
}
