﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Shop.Test.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("FilteringProducts", Description="    In order to find disired products\r\n    As a user of the website\r\n    I want t" +
        "o get necessary products after filtering", SourceFile="Features\\FilteringProducts.feature", SourceLine=0)]
    public partial class FilteringProductsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FilteringProducts.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "FilteringProducts", "    In order to find disired products\r\n    As a user of the website\r\n    I want t" +
                    "o get necessary products after filtering", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void GettingAppropriateProductsAfterFilteringByBrandsIfBrandsProductsExist(string brand, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "filtering"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting appropriate products after filtering  by brands if brand\'s products exist" +
                    "", @__tags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given(string.Format("If brand\'s products exist I have entered brand  {0}", brand), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
    testRunner.When("I press search if necessary products exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
    testRunner.Then("Get products if necessary products exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Getting appropriate products after filtering  by brands if brand\'s products exist" +
            ", testbrand_1", new string[] {
                "filtering"}, SourceLine=12)]
        public virtual void GettingAppropriateProductsAfterFilteringByBrandsIfBrandsProductsExist_Testbrand_1()
        {
#line 7
this.GettingAppropriateProductsAfterFilteringByBrandsIfBrandsProductsExist("testbrand_1", ((string[])(null)));
#line hidden
        }
        
        public virtual void GettingAppropriateProductsAfterFilteringByBrandsIfBrandsProductsDoNotExist(string brand, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "filtering"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting appropriate products after filtering  by brands if brand\'s products do no" +
                    "t exist", @__tags);
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
    testRunner.Given(string.Format("if brand\'s products do not exist I have entered brand  {0}", brand), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
    testRunner.When("I press search if necessary products do not exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
    testRunner.Then("Do not get products if necessary products do not exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Getting appropriate products after filtering  by brands if brand\'s products do no" +
            "t exist, testbrand_2", new string[] {
                "filtering"}, SourceLine=21)]
        public virtual void GettingAppropriateProductsAfterFilteringByBrandsIfBrandsProductsDoNotExist_Testbrand_2()
        {
#line 16
this.GettingAppropriateProductsAfterFilteringByBrandsIfBrandsProductsDoNotExist("testbrand_2", ((string[])(null)));
#line hidden
        }
        
        public virtual void GettingAppropriateProductsAfterFilteringByPriceIfProductsWithThisPriceExist(string minprice, string maxprice, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "filtering"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting appropriate products after filtering  by price if products with this pric" +
                    "e exist", @__tags);
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
    testRunner.Given(string.Format("If products with this price exist I have entered min price {0} and max price {1}", minprice, maxprice), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
    testRunner.When("I press search if necessary products exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
    testRunner.Then("Get products if necessary products exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Getting appropriate products after filtering  by price if products with this pric" +
            "e exist, 10", new string[] {
                "filtering"}, SourceLine=30)]
        public virtual void GettingAppropriateProductsAfterFilteringByPriceIfProductsWithThisPriceExist_10()
        {
#line 25
this.GettingAppropriateProductsAfterFilteringByPriceIfProductsWithThisPriceExist("10", "100", ((string[])(null)));
#line hidden
        }
        
        public virtual void GettingAppropriateProductsAfterFilteringByPriceIfProductsWithThisPriceDoNotExist(string minprice, string maxprice, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "filtering"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting appropriate products after filtering  by price if products with this pric" +
                    "e do not exist", @__tags);
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
    testRunner.Given(string.Format("If products with this price do not exist I have entered min price {0} and max pri" +
                        "ce {1}", minprice, maxprice), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
    testRunner.When("I press search if necessary products do not exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
    testRunner.Then("Do not get products if necessary products do not exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Getting appropriate products after filtering  by price if products with this pric" +
            "e do not exist, 101", new string[] {
                "filtering"}, SourceLine=39)]
        public virtual void GettingAppropriateProductsAfterFilteringByPriceIfProductsWithThisPriceDoNotExist_101()
        {
#line 34
this.GettingAppropriateProductsAfterFilteringByPriceIfProductsWithThisPriceDoNotExist("101", "200", ((string[])(null)));
#line hidden
        }
        
        public virtual void GettingAppropriateProductsAfterFilteringByNameIfProductsWithThisNameExist(string word, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "filtering"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting appropriate products after filtering by name if products with this name e" +
                    "xist", @__tags);
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
    testRunner.Given(string.Format("If products with this name exist I have entered name {0} in the searchstring", word), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
    testRunner.When("I press search if necessary products exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
    testRunner.Then("Get products if necessary products exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Getting appropriate products after filtering by name if products with this name e" +
            "xist, testname", new string[] {
                "filtering"}, SourceLine=48)]
        public virtual void GettingAppropriateProductsAfterFilteringByNameIfProductsWithThisNameExist_Testname()
        {
#line 43
this.GettingAppropriateProductsAfterFilteringByNameIfProductsWithThisNameExist("testname", ((string[])(null)));
#line hidden
        }
        
        public virtual void GettingAppropriateProductsAfterFilteringByNameIfProductsWithThisNameDoNotExist(string word, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "filtering"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting appropriate products after filtering  by name if products with this name " +
                    "do not exist", @__tags);
#line 52
this.ScenarioSetup(scenarioInfo);
#line 53
    testRunner.Given(string.Format("If products with this name do not exist I have entered name {0} in the searchstri" +
                        "ng", word), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
    testRunner.When("I press search if necessary products do not exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
    testRunner.Then("Do not get products if necessary products do not exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Getting appropriate products after filtering  by name if products with this name " +
            "do not exist, unknownname", new string[] {
                "filtering"}, SourceLine=57)]
        public virtual void GettingAppropriateProductsAfterFilteringByNameIfProductsWithThisNameDoNotExist_Unknownname()
        {
#line 52
this.GettingAppropriateProductsAfterFilteringByNameIfProductsWithThisNameDoNotExist("unknownname", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion