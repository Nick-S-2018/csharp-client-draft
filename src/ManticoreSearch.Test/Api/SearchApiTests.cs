/*
 * Manticore Search Client
 *
 * Low-level client for Manticore Search. 
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: info@manticoresearch.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Xunit;
using System.Net.Http;
using System.Text.Json;

using ManticoreSearch.Client;
using ManticoreSearch.Api;
// uncomment below to import models
using ManticoreSearch.Model;

namespace ManticoreSearch.Test.Api
{
    /// <summary>
    ///  Class for testing SearchApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class SearchApiTests : IDisposable
    {
    	private SearchApi instance;
        private HttpClientHandler httpClientHandler;
        private HttpClient httpClient;
        private Configuration config;

        private Dictionary<string, Dictionary<string,Func<Object>>> implementedTests;

        private void InitTests()
        {
            config = new Configuration();
            config.BasePath = "http://manticoresearch-manticore:9308";
            httpClient = new HttpClient();
            httpClientHandler = new HttpClientHandler();
            instance = new SearchApi(httpClient, config, httpClientHandler);
        }
                
        private object CheckTest(string testName)
        {
            Dictionary<string,Func<Object>> classTests;
            if (implementedTests.TryGetValue("SearchApi", out classTests))
            {
                Func<Object> test;    
                if (classTests.TryGetValue(testName, out test))
                {
                    return test();
                }
            }
            return null;
        }     
        
        public SearchApiTests()
        {
            implementedTests = new Dictionary<string, Dictionary<string,Func<Object>>>()
            {
                {
                "SearchApi", 
                    new Dictionary<string, Func<Object>>()
                    {
                    	{ "SearchTest", () => 
                            {
                            	var utilsApi = new UtilsApi();
                        		utilsApi.Sql("DROP TABLE IF EXISTS movies", true);
					        	utilsApi.Sql("CREATE TABLE IF NOT EXISTS movies (title text, plot text, year integer, rating float, code multi)", true);
					        	
					        	string[] docs = {
									"{\"insert\": {\"index\" : \"movies\", \"id\" : 1, \"doc\" : {\"title\" : \"Star Trek 2: Nemesis\", \"plot\": \"The Enterprise is diverted to the Romulan homeworld Romulus, supposedly because they want to negotiate a peace treaty. Captain Picard and his crew discover a serious threat to the Federation once Praetor Shinzon plans to attack Earth.\", \"year\": 2002, \"rating\": 6.4, \"code\": [1,2,3]}}}",
						            "{\"insert\": {\"index\" : \"movies\", \"id\" : 2, \"doc\" : {\"title\" : \"Star Trek 1: Nemesis\", \"plot\": \"The Enterprise is diverted to the Romulan homeworld Romulus, supposedly because they want to negotiate a peace treaty. Captain Picard and his crew discover a serious threat to the Federation once Praetor Shinzon plans to attack Earth.\", \"year\": 2001, \"rating\": 6.5, \"code\": [1,12,3]}}}",
						            "{\"insert\": {\"index\" : \"movies\", \"id\" : 3, \"doc\" : {\"title\" : \"Star Trek 3: Nemesis\", \"plot\": \"The Enterprise is diverted to the Romulan homeworld Romulus, supposedly because they want to negotiate a peace treaty. Captain Picard and his crew discover a serious threat to the Federation once Praetor Shinzon plans to attack Earth.\", \"year\": 2003, \"rating\": 6.6, \"code\": [11,2,3]}}}",
						            "{\"insert\": {\"index\" : \"movies\", \"id\" : 4, \"doc\" : {\"title\" : \"Star Trek 4: Nemesis\", \"plot\": \"The Enterprise is diverted to the Romulan homeworld Romulus, supposedly because they want to negotiate a peace treaty. Captain Picard and his crew discover a serious threat to the Federation once Praetor Shinzon plans to attack Earth.\", \"year\": 2003, \"rating\": 6.5, \"code\": [1,2,4]}}}"					        	
						        };
					        						        	
	                			var indexApi = new IndexApi(httpClient, config, httpClientHandler);
	            				var res = indexApi.Bulk(string.Join("\n", docs));
	            				
		            			object query =  new { query_string="Star" };
		            				
		            			var searchRequest = new SearchRequest("movies", query);

								searchRequest.Limit = 10;
								
								searchRequest.Options = new Dictionary<string, Object>();
								searchRequest.Options["cutoff"] = 5;
								searchRequest.Options["ranker"] = "bm25";
        						searchRequest.Source = "title";
        													
	        					var includes = new List<string> {"title", "year"};
        						var excludes = new List<string> {"code"};
        						searchRequest.Source = new SourceByRules(includes, excludes);
	        					
	        					searchRequest.Sort = new List<Object> {"year"};
	        					var sort2 = new SortOrder("rating", SortOrder.OrderEnum.Asc);
	        					searchRequest.Sort.Add(sort2);
	        					var sort3 = new SortMVA("code", SortMVA.OrderEnum.Desc, SortMVA.ModeEnum.Max);
	        					searchRequest.Sort.Add(sort3);
	        					
	        					var expr = new Dictionary<string, string> { {"expr", "min(year,2900)"} };
	        					searchRequest.Expressions = new List<Object>();
					        	searchRequest.Expressions.Add(expr);
					        	searchRequest.Expressions.Add( new Dictionary<string, string> { {"expr2", "max(year,2100)"} } );
					        	includes.Add("expr2");
					        	searchRequest.Source = new SourceByRules(includes, excludes);
					        	
					        	var agg1 = new Aggregation("agg1", "year");
					        	agg1.Size = 10;
        						searchRequest.Aggs = new List<Aggregation> {agg1};
        						searchRequest.Aggs.Add(new Aggregation("agg2", "rating"));
					        	
					        	var highlight = new Highlight();
					        	highlight.Fieldnames = new List<string> {"title"};
 					        	highlight.PostTags = "</post_tag>";
 					    	    highlight.Encoder = Highlight.EncoderEnum.Default;
 						        highlight.SnippetBoundary = Highlight.SnippetBoundaryEnum.Sentence;
 					        	searchRequest.Highlight = highlight;
        	
					        	var highlightField = new HighlightField("title");
								highlightField.Limit = 5;
								highlight.Fields = new List<HighlightField> {highlightField};
								
								var highlightField2 = new HighlightField("plot");
								highlightField2.LimitWords = 10;
					        	highlight.Fields.Add(highlightField2);
					        	searchRequest.Highlight = highlight;
					        	
					        	searchRequest.FulltextFilter = new QueryFilter("Star Trek 2");
					        	searchRequest.FulltextFilter = new MatchFilter("Nemesis", "title");
					        	searchRequest.FulltextFilter = new MatchPhraseFilter("Star Trek 2", "title");
					        	searchRequest.FulltextFilter = new MatchOpFilter("Enterprise test", "title,plot", MatchOpFilter.OperatorEnum.Or);
					        	
					        	searchRequest.AttrFilter = new EqualsFilter("year", 2003);
					        	
					        	var inFilter = new InFilter("year", new List<Object> {2001, 2002});
					        	var addValues = new List<Object> {10,11};
					    	    inFilter.Values.AddRange(addValues);
						        searchRequest.AttrFilter = inFilter;
	        
	        					var rangeFilter = new RangeFilter("year");
								rangeFilter.Lte = 2002;
								rangeFilter.Gte = 1000;
								searchRequest.AttrFilter = rangeFilter;
								
								var geoFilter = new GeoDistanceFilter();
								var locAnchor = new GeoDistanceFilterLocationAnchor(10, 20);
								geoFilter.LocationAnchor = locAnchor;
								geoFilter.LocationSource = "field3,field4";
								geoFilter.DistanceType = GeoDistanceFilter.DistanceTypeEnum.Adaptive;
								geoFilter.Distance = "100km";
        						//searchRequest.AttrFilter = geoFilter;
	        		        					
        						var boolFilter = new BoolFilter();
        						boolFilter.Must = new List<Object> { new EqualsFilter("year", 2001) };
        						rangeFilter = new RangeFilter("rating");
								rangeFilter.Lte = 20;
        						boolFilter.Must.Add(rangeFilter);
        						searchRequest.AttrFilter = boolFilter;
        	
        						boolFilter.MustNot = new List<Object> { new EqualsFilter("year", 2001) };
								searchRequest.AttrFilter = boolFilter;
								
								var fulltextFilter = new MatchFilter("Star", "title");
        						var nestedBoolFilter = new BoolFilter();
        						nestedBoolFilter.Should = new List<Object> { new EqualsFilter("rating", 6.5), fulltextFilter };
        						boolFilter.Must = new List<Object> {nestedBoolFilter};
            					searchRequest.AttrFilter = boolFilter;
        	
        						var searchApi = new SearchApi();
                                var searchRes = searchApi.Search(searchRequest);
                                
                                return searchRes;
                                
                            }
                        },
                    }
                 },
                 {
                 "IndexApi", 
                    new Dictionary<string, Func<Object>>()
                    {
                        { "InsertTest", () => 
                            {
                            	string body = "CREATE TABLE IF NOT EXISTS test (body text, title string)";
            					var utilsApi = new UtilsApi();
            					utilsApi.Sql(body, true);
                                Dictionary<string, Object> doc = new Dictionary<string, Object>(); 
                                doc.Add("body", "test");
                                doc.Add("title", "test");
                                InsertDocumentRequest insertDocumentRequest = new InsertDocumentRequest(index: "test", id: 1, doc: doc);
                                insertDocumentRequest = new InsertDocumentRequest(index: "test", id: 2, doc: doc);
                                var obj = new IndexApi(httpClient, config, httpClientHandler);
                                return obj.Insert(insertDocumentRequest);
                            }
                        },
                        { "BulkTest", () => 
		                	{
		                		string body = "CREATE TABLE IF NOT EXISTS test (body text, title string)";
            					var utilsApi = new UtilsApi();
            					utilsApi.Sql("DROP TABLE IF EXISTS test", true);
            					utilsApi.Sql(body, true);
		                		body = "{\"insert\": {\"index\": \"test\", \"id\": 1, \"doc\": {\"body\": \"test\", \"title\": \"test\"}}}" + "\n";
		                		var obj = new IndexApi(httpClient, config, httpClientHandler);
		            			return obj.Bulk(body);
		                	}
		                },
		                { "ReplaceTest", () => 
		                	{
								Dictionary<string, Object> doc = new Dictionary<string, Object>(); 
		            			doc.Add("body", "test 2");
		            			doc.Add("title", "test");
		            			InsertDocumentRequest insertDocumentRequest = new InsertDocumentRequest(index: "test", id: 1, doc: doc);
		            			var obj = new IndexApi(httpClient, config, httpClientHandler);
		            			return obj.Replace(insertDocumentRequest);
		                	}
		                },
		                { "UpdateTest", () => 
		                	{
								Dictionary<string, Object> doc = new Dictionary<string, Object>();
					            doc.Add("title", "test 2");
					            UpdateDocumentRequest updateDocumentRequest = new UpdateDocumentRequest(index: "test", id: 2, doc: doc);
					            var obj = new IndexApi(httpClient, config, httpClientHandler);
					            return obj.Update(updateDocumentRequest);
		                	}
		                },
		                { "DeleteTest", () => 
		                	{
								DeleteDocumentRequest deleteDocumentRequest = new DeleteDocumentRequest(index: "test", id: 1);
								var obj = new IndexApi(httpClient, config, httpClientHandler);
		            			return obj.Delete(deleteDocumentRequest);
		                	}
		                },
                    }
                }
            };

            InitTests();
            
        }

        public void Dispose()
        {
        }

        /// <summary>
        /// Test an instance of SearchApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            Assert.IsType<SearchApi>(instance);
        }

        /// <summary>
        /// Test Percolate
        /// </summary>
        [Fact]
        public void PercolateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string index = null;
            //PercolateRequest percolateRequest = null;
            //var response = instance.Percolate(index, percolateRequest);
			object response = this.CheckTest( System.Reflection.MethodBase.GetCurrentMethod().Name );
            if (response != null)
            {
            	Assert.IsType<SearchResponse>(response);
            }
        }

        /// <summary>
        /// Test Search
        /// </summary>
        [Fact]
        public void SearchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //SearchRequest searchRequest = null;
            //var response = instance.Search(searchRequest);
			object response = this.CheckTest( System.Reflection.MethodBase.GetCurrentMethod().Name );
            if (response != null)
            {
            	Assert.IsType<SearchResponse>(response);
            }
        }
    }
}
