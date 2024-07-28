﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace PlaywrigthSpecFlow.Features.WebTable
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("WebTableTest")]
    [NUnit.Framework.CategoryAttribute("ReusesFeatureDriver")]
    [NUnit.Framework.CategoryAttribute("WebPageLogin")]
    public partial class WebTableTestFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "ReusesFeatureDriver",
                "WebPageLogin"};
        
#line 1 "WebTableTests.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/WebTable", "WebTableTest", "  As a User, I want to add a new item to the web table,\r\n  so that I can see the " +
                    "new item in the table,\r\n  and I can delete and edit items.", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I see item in the table")]
        [NUnit.Framework.TestCaseAttribute("Cierra", "Vega", null)]
        [NUnit.Framework.TestCaseAttribute("Alden", "Cantrell", null)]
        [NUnit.Framework.TestCaseAttribute("Kierra", "Gentry", null)]
        public void ISeeItemInTheTable(string firstName, string lastName, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I see item in the table", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 9
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 10
 testRunner.Given("I am on DemoQA WebTable Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 11
 testRunner.When("I see the WebTable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 12
 testRunner.Then(string.Format("I see FirstName \"{0}\" in a table", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 13
    testRunner.And(string.Format("I see LastName \"{0}\" in a table", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I add item to the table")]
        [NUnit.Framework.TestCaseAttribute("Astolfo", "Rider", "astolfo.rider@e.com", "24", "13800", "Fate/GO", null)]
        [NUnit.Framework.TestCaseAttribute("Felix", "Argyle", "felix.argyle@e.com", "27", "10600", "Re: Life", null)]
        [NUnit.Framework.TestCaseAttribute("Hideyoshi", "Kinoshita", "hideyoshi.k@e.com", "17", "7600", "Baka&Test", null)]
        [NUnit.Framework.TestCaseAttribute("Hideri", "Kanzaki", "hideri.k@e.com", "19", "10800", "Blend S", null)]
        [NUnit.Framework.TestCaseAttribute("Izumi", "Asakawa", "izumi.asakawa@e.com", "21", "11400", "Game of Life", null)]
        [NUnit.Framework.TestCaseAttribute("Envy", "Sevenfold", "envy.seven@e.com", "26", "12400", "FMA", null)]
        [NUnit.Framework.TestCaseAttribute("Nagisa", "Shiota", "nagisa.shiota@e.com", "16", "6800", "Assassination", null)]
        [NUnit.Framework.TestCaseAttribute("Erika", "Kudo", "erika.kudo@e.com", "22", "9300", "Durarara", null)]
        [NUnit.Framework.TestCaseAttribute("Pico", "DeColette", "pico.deco@e.com", "28", "12600", "Boku no Pico", null)]
        [NUnit.Framework.TestCaseAttribute("Nitori", "Kawashiro", "nitori.kawa@e.com", "30", "10200", "Touhou", null)]
        [NUnit.Framework.TestCaseAttribute("Najimi", "Osana", "najimi.osana@e.com", "18", "13000", "Komi Can\'t", null)]
        [NUnit.Framework.TestCaseAttribute("Yoru", "Kurogane", "yoru.kuro@e.com", "25", "13600", "Triage X", null)]
        [NUnit.Framework.TestCaseAttribute("Suigetsu", "Hozuki", "suigetsu.h@e.com", "31", "14000", "Naruto", null)]
        [NUnit.Framework.TestCaseAttribute("Kagerou", "Shoukiin", "kagerou.s@e.com", "20", "8800", "EnSt", null)]
        [NUnit.Framework.TestCaseAttribute("Saki", "Mitsuki", "saki.mitsuki@e.com", "24", "14200", "Sweet Devil", null)]
        [NUnit.Framework.TestCaseAttribute("Kaito", "Shindou", "kaito.shindou@e.com", "26", "12600", "Sweet Devil", null)]
        [NUnit.Framework.TestCaseAttribute("Ryu", "Hanazawa", "ryu.hanazawa@e.com", "22", "14400", "Sweet Devil", null)]
        [NUnit.Framework.TestCaseAttribute("Luka", "Takahashi", "luka.takaha@e.com", "23", "10400", "Sweet Devil", null)]
        [NUnit.Framework.TestCaseAttribute("Kumagawa", "Misogi", "kumagawa.m@e.com", "25", "9800", "Medaka Box", null)]
        [NUnit.Framework.TestCaseAttribute("Gottfried", "Beckett", "gottfried.b@e.com", "28", "14800", "Gothic Lolita", null)]
        [NUnit.Framework.TestCaseAttribute("Chihiro", "Fujisaki", "chihiro.f@e.com", "27", "9400", "Danganronpa", null)]
        [NUnit.Framework.TestCaseAttribute("Haruka", "Nanase", "haruka.nanase@e.com", "22", "12200", "Free!", null)]
        [NUnit.Framework.TestCaseAttribute("Kaoru", "Hanayama", "kaoru.hanaya@e.com", "30", "11600", "Sakamoto", null)]
        [NUnit.Framework.TestCaseAttribute("Ryouta", "Kise", "ryouta.kise@e.com", "22", "13400", "No Thank You", null)]
        [NUnit.Framework.TestCaseAttribute("Nanako", "Amasawa", "nanako.amasa@e.com", "24", "14200", "Girls,Girls", null)]
        [NUnit.Framework.TestCaseAttribute("Leo", "Tsukinaga", "leo.tsukinaga@e.com", "28", "12800", "EnSt", null)]
        [NUnit.Framework.TestCaseAttribute("Bright", "Noa", "bright.noa@e.com", "23", "10600", "Guilty Gear", null)]
        [NUnit.Framework.TestCaseAttribute("Miki", "Takamine", "miki.takami@e.com", "25", "14800", "Girls,Girls", null)]
        [NUnit.Framework.TestCaseAttribute("Arata", "Matsunaga", "arata.matsuna@e.com", "21", "10800", "Girls,Girls", null)]
        [NUnit.Framework.TestCaseAttribute("Saki", "Nagase", "saki.nagase@e.com", "27", "11600", "Girls,Girls", null)]
        [NUnit.Framework.TestCaseAttribute("Ayame", "Inoue", "ayame.inoue@e.com", "31", "13000", "Himegoto", null)]
        [NUnit.Framework.TestCaseAttribute("Shinya", "Kaito", "shinya.kaito@e.com", "30", "10800", "Himegoto", null)]
        [NUnit.Framework.TestCaseAttribute("Mutsuki", "Ito", "mutsuki.ito@e.com", "21", "11400", "Himegoto", null)]
        [NUnit.Framework.TestCaseAttribute("Ruka", "Yamada", "ruka.yamada@e.com", "32", "12600", "Himegoto", null)]
        [NUnit.Framework.TestCaseAttribute("Ryu", "Tano", "ryu.tano@e.com", "28", "13600", "Himegoto", null)]
        [NUnit.Framework.TestCaseAttribute("Kotaro", "Saito", "kotaro.saito@e.com", "25", "12400", "Himegoto", null)]
        [NUnit.Framework.TestCaseAttribute("Takato", "Yagami", "takato.yagami@e.com", "23", "14400", "Oniichan", null)]
        [NUnit.Framework.TestCaseAttribute("Makoto", "Haruka", "makoto.haruka@e.com", "26", "11800", "Uta no Prince", null)]
        [NUnit.Framework.TestCaseAttribute("Saiki", "Kiyoshi", "saiki.kiyoshi@e.com", "22", "13600", "MyDearestLove", null)]
        [NUnit.Framework.TestCaseAttribute("Riku", "Aki", "riku.aki@e.com", "24", "14200", "Koi no Kimochi", null)]
        [NUnit.Framework.TestCaseAttribute("Kaoru", "Saki", "kaoru.saki@e.com", "25", "11600", "Dandelion", null)]
        [NUnit.Framework.TestCaseAttribute("Yuuto", "Nakagawa", "yuuto.nakaga@e.com", "27", "12600", "Niku Saku", null)]
        [NUnit.Framework.TestCaseAttribute("Tsubasa", "Hirose", "tsubasa.hiro@e.com", "22", "10400", "CielNosurge", null)]
        [NUnit.Framework.TestCaseAttribute("Yuto", "Shinohara", "yuto.shino@e.com", "30", "14000", "Himegoto", null)]
        [NUnit.Framework.TestCaseAttribute("Ryuichi", "Yamamoto", "ryuichi.yama@e.com", "24", "12200", "FemDream", null)]
        [NUnit.Framework.TestCaseAttribute("Kanata", "Shinkai", "kanata.shink@e.com", "26", "12800", "OtomeGame", null)]
        [NUnit.Framework.TestCaseAttribute("Shun", "Takato", "shun.takato@e.com", "22", "11400", "MyGenderless", null)]
        [NUnit.Framework.TestCaseAttribute("Daichi", "Akimoto", "daichi.akim@e.com", "27", "12100", "OtomeTeikou", null)]
        [NUnit.Framework.TestCaseAttribute("Tsubasa", "Hanazawa", "tsubasa.hanaz@e.com", "26", "10600", "Junjou", null)]
        [NUnit.Framework.TestCaseAttribute("Keiji", "Kuroda", "keiji.kurod@e.com", "23", "14800", "PrinceTennis", null)]
        public void IAddItemToTheTable(string firstName, string lastName, string email, string age, string salary, string department, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("Email", email);
            argumentsOfScenario.Add("Age", age);
            argumentsOfScenario.Add("Salary", salary);
            argumentsOfScenario.Add("Department", department);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I add item to the table", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
   this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 22
 testRunner.Given("I am on DemoQA WebTable Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
 testRunner.When("I see the WebTable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.And("I click Add Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 25
 testRunner.And(string.Format("I set FirstName to \"{0}\"", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
    testRunner.And(string.Format("I set LastName to \"{0}\"", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 27
    testRunner.And(string.Format("I set Email \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
    testRunner.And(string.Format("I set Age \"{0}\"", age), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
    testRunner.And(string.Format("I set Salary \"{0}\"", salary), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 30
    testRunner.And(string.Format("I set Department \"{0}\"", department), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 31
    testRunner.And("I click Submit Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
     testRunner.Then(string.Format("I see FirstName \"{0}\" in a table", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 33
     testRunner.And(string.Format("I see LastName \"{0}\" in a table", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
     testRunner.And(string.Format("I see Email \"{0}\" in a table", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
     testRunner.And(string.Format("I see Age \"{0}\" in a table", age), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
     testRunner.And(string.Format("I see Salary \"{0}\" in a table", salary), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 37
     testRunner.And(string.Format("I see Department \"{0}\" in a table", department), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I edit item in the table")]
        [NUnit.Framework.TestCaseAttribute("Astolfo", "Rider", "astolfo.rider@e.com", "24", "13800", "Fate/GO", "25000", null)]
        public void IEditItemInTheTable(string firstName, string lastName, string email, string age, string salary, string department, string newSalary, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("Email", email);
            argumentsOfScenario.Add("Age", age);
            argumentsOfScenario.Add("Salary", salary);
            argumentsOfScenario.Add("Department", department);
            argumentsOfScenario.Add("New Salary", newSalary);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I edit item in the table", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 93
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 94
 testRunner.Given("I am on DemoQA WebTable Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 95
    testRunner.When("I see the WebTable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 96
 testRunner.And("I click Add Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 97
 testRunner.And(string.Format("I set FirstName to \"{0}\"", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 98
    testRunner.And(string.Format("I set LastName to \"{0}\"", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 99
    testRunner.And(string.Format("I set Email \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 100
    testRunner.And(string.Format("I set Age \"{0}\"", age), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 101
    testRunner.And(string.Format("I set Salary \"{0}\"", salary), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 102
    testRunner.And(string.Format("I set Department \"{0}\"", department), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 103
    testRunner.And("I click Submit Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 104
    testRunner.Then(string.Format("I see FirstName \"{0}\" in a table", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 106
    testRunner.When("I am editing row number \"4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 107
    testRunner.And(string.Format("I set Salary \"{0}\"", newSalary), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 108
    testRunner.And("I click Submit Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 109
    testRunner.Then(string.Format("I see Salary \"{0}\" in a table", newSalary), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I delete row in the table")]
        [NUnit.Framework.TestCaseAttribute("Astolfo", "Rider", "astolfo.rider@e.com", "24", "13800", "Fate/GO", null)]
        public void IDeleteRowInTheTable(string firstName, string lastName, string email, string age, string salary, string department, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("Email", email);
            argumentsOfScenario.Add("Age", age);
            argumentsOfScenario.Add("Salary", salary);
            argumentsOfScenario.Add("Department", department);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I delete row in the table", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 115
     this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 116
 testRunner.Given("I am on DemoQA WebTable Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 118
    testRunner.When("I see the WebTable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 119
 testRunner.And("I click Add Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 120
 testRunner.And(string.Format("I set FirstName to \"{0}\"", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 121
    testRunner.And(string.Format("I set LastName to \"{0}\"", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 122
    testRunner.And(string.Format("I set Email \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 123
    testRunner.And(string.Format("I set Age \"{0}\"", age), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 124
    testRunner.And(string.Format("I set Salary \"{0}\"", salary), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 125
    testRunner.And(string.Format("I set Department \"{0}\"", department), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 126
    testRunner.And("I click Submit Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 127
    testRunner.Then(string.Format("I see FirstName \"{0}\" in a table", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 129
    testRunner.When("I am deleting row number \"4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 130
    testRunner.Then(string.Format("I dont see Row \"{0}\" in a table", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
