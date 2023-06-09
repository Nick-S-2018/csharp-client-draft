# ManticoreSearch.Api.SearchApi

All URIs are relative to *http://127.0.0.1:9308*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**Percolate**](SearchApi.md#percolate) | **POST** /json/pq/{index}/search | Perform reverse search on a percolate index |
| [**Search**](SearchApi.md#search) | **POST** /json/search | Performs a search |

<a name="percolate"></a>
# **Percolate**
> SearchResponse Percolate (string index, PercolateRequest percolateRequest)

Perform reverse search on a percolate index

Performs a percolate search.  This method must be used only on percolate indexes.  
Expects two parameters: the index name and an object with array of documents to be tested. 
An example of the documents object:    
```   
{\"query\":{\"percolate\":{\"document\":{\"content\":\"sample content\"}}}}   
```  

Responds with an object with matched stored queries:     
```   
{'timed_out':false,'hits':{'total':2,'max_score':1,'hits':[{'_index':'idx_pq_1','_type':'doc','_id':'2','_score':'1','_source':{'query':{'match':{'title':'some'},}}},{'_index':'idx_pq_1','_type':'doc','_id':'5','_score':'1','_source':{'query':{'ql':'some | none'}}}]}}   
``` 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using ManticoreSearch.Api;
using ManticoreSearch.Client;
using ManticoreSearch.Model;

namespace Example
{
    public class PercolateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://127.0.0.1:9308";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new SearchApi(httpClient, config, httpClientHandler);
            var index = "index_example";  // string | Name of the percolate index
            var percolateRequest = new PercolateRequest(); // PercolateRequest | 

            try
            {
                // Perform reverse search on a percolate index
                SearchResponse result = apiInstance.Percolate(index, percolateRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchApi.Percolate: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PercolateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Perform reverse search on a percolate index
    ApiResponse<SearchResponse> response = apiInstance.PercolateWithHttpInfo(index, percolateRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchApi.PercolateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **index** | **string** | Name of the percolate index |  |
| **percolateRequest** | [**PercolateRequest**](PercolateRequest.md) |  |  |

### Return type

[**SearchResponse**](SearchResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | items found |  -  |
| **0** | error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="search"></a>
# **Search**
> SearchResponse Search (SearchRequest searchRequest)

Performs a search

Expects an object with mandatory properties: 
 * the index name 
 * the match query object 
 
Example :    
```   
{'index':'movies','query':{'bool':{'must':[{'query_string':' movie'}]}},'script_fields':{'myexpr':{'script':{'inline':'IF(rating>8,1,0)'}}},'sort':[{'myexpr':'desc'},{'_score':'desc'}],'profile':true}   
```  

It responds with an object with: 
- time of execution 
- if the query is timed out 
- an array with hits (matched documents) found 
- if profiling is enabled, an additional array with profiling information attached     

```   
{'took':10,'timed_out':false,'hits':{'total':2,'hits':[{'_id':'1','_score':1,'_source':{'gid':11}},{'_id':'2','_score':1,'_source':{'gid':12}}]}}   
```  

Alternatively, you can use auxiliary objects(`fulltextFilter` or `attrFilter`) to build your search queries as it's shown in the example below. 
For more information about the match query syntax and additional parameters that can be added to  request and response, please check: https://manual.manticoresearch.com/Searching/Full_text_matching/Basic_usage#HTTP. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using ManticoreSearch.Api;
using ManticoreSearch.Client;
using ManticoreSearch.Model;

namespace Example
{
    public class SearchExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://127.0.0.1:9308";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new SearchApi(httpClient, config, httpClientHandler);
            var searchRequest = new SearchRequest(); 

            try
            {
                // Performs a search
                SearchResponse result = apiInstance.Search(searchRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchApi.Search: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### SearchRequest

[[Detailed information on search options]](https://manual.manticoresearch.com/Searching/Options#Search-options)
```csharp
object query =  new { query_string="Star" };
var searchRequest = new SearchRequest("movies", query);

searchRequest.Limit = 10;
searchRequest.TrackScores = true;
searchRequest.Options = new Dictionary<string, Object>();
searchRequest.Options["cutoff"] = 5;
searchRequest.Options["ranker"] = "bm25";
searchRequest.Source = "title";

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

### SourceByRules

[[SourceByRules]](SourceByRules.md)

[[Detailed information on the `source` property]](https://manual.manticoresearch.com/Searching/Search_results#Source-selection)
```csharp
//Setting the `Source` property with an auxiliary object:
object query =  new { query_string="Star" };
var searchRequest = new SearchRequest("movies", query);

var includes = new List<string> {"title", "year"};
var excludes = new List<string> {"code"};
searchRequest.Source = new SourceByRules(includes, excludes);

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

### Sort
```csharp
//Setting the `Sort` property:
object query =  new { query_string="Star" };
var searchRequest = new SearchRequest("movies", query);

searchRequest.Sort = new List<Object> {"year"};

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

### SortOrder
### SortMVA

[[SortOrder]](SortOrder.md)
[[SortMVA]](SortMVA.md)

[[Detailed information on sorting]](https://manual.manticoresearch.com/Searching/Sorting_and_ranking#HTTP)
```csharp
//Setting the `Sort` property with an auxiliary object:
object query =  new { query_string="Star" };
var searchRequest = new SearchRequest("movies", query);

searchRequest.Sort = new List<Object>();
var sort2 = new SortOrder("rating", SortOrder.OrderEnum.Asc);
searchRequest.Sort.Add(sort2);
var sort3 = new SortMVA("code", SortMVA.OrderEnum.Desc, SortMVA.ModeEnum.Max);
searchRequest.Sort.Add(sort3);

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

### Expressions

[[Detailed information on expressions]](https://manual.manticoresearch.com/Searching/Expressions#Expressions-in-HTTP-JSON)
```csharp    
//Setting the `expressions` property:
object query =  new { query_string="Star" };
var searchRequest = new SearchRequest("movies", query);

var expr = new Dictionary<string, string> { {"expr", "min(year,2900)"} };
searchRequest.Expressions = new List<Object>();
searchRequest.Expressions.Add(expr);
searchRequest.Expressions.Add( new Dictionary<string, string> { {"expr2", "max(year,2100)"} } );
					        	
SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

### Aggregation

[[Aggregation]](Aggregation.md)

[[Detailed information on aggregations](https://manual.manticoresearch.com/Searching/Faceted_search#Aggregations)
```csharp    
//Setting the `aggs` property with an auxiliary object:
object query =  new { query_string="Star" };
var searchRequest = new SearchRequest("movies", query);

var agg1 = new Aggregation("agg1", "year");
agg1.Size = 10;
searchRequest.Aggs = new List<Aggregation> {agg1};
searchRequest.Aggs.Add(new Aggregation("agg2", "rating"));

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

### Highlight

[[Highlight]](Highlight.md)

[[Detailed information on highlighting]](https://manual.manticoresearch.com/Searching/Highlighting#Highlighting)
```csharp
//Settting the `highlight` property with an auxiliary object:
object query =  new { query_string="Star" };
var searchRequest = new SearchRequest("movies", query);

var highlight = new Highlight();
highlight.Fieldnames = new List<string> {"title"};
highlight.PostTags = "</post_tag>";
highlight.Encoder = Highlight.EncoderEnum.Default;
highlight.SnippetBoundary = Highlight.SnippetBoundaryEnum.Sentence;
searchRequest.Highlight = highlight;

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

#### HighlightField

[[HighlightField]](HighlightField.md)

[[Detailed information on highlighting]](https://manual.manticoresearch.com/Searching/Highlighting#Highlighting)
```csharp
// settting `highlight.fields` property with an auxiliary HighlightField object
object query =  new { query_string="Star" };
var searchRequest = new SearchRequest("movies", query);

var highlight = new Highlight();
var highlightField = new HighlightField("title");
highlightField.Limit = 5;
highlight.Fields = new List<HighlightField> {highlightField};

var highlightField2 = new HighlightField("plot");
highlightField2.LimitWords = 10;
highlight.Fields.Add(highlightField2);
searchRequest.Highlight = highlight;

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

### FulltextFilter
#### QueryFilter

[[Detailed information on fulltext filters]](https://manual.manticoresearch.com/Searching/Full_text_matching/Basic_usage#HTTP)

[[QueryFilter]](QueryFilter.md)
```csharp    
//Setting the `FulltextFilter` property using different fulltext filter objects:

//Using a QueryFilter object
var searchRequest = new SearchRequest("movies");

searchRequest.FulltextFilter = new QueryFilter("Star Trek 2");

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

#### MatchFilter

[[MatchFilter]](MatchFilter.md)
```csharp    
//Using a MatchFilter object
var searchRequest = new SearchRequest("movies");

searchRequest.FulltextFilter = new MatchFilter("Nemesis", "title");

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

#### MatchPhraseFilter

[[MatchPhraseFilter]](MatchPhraseFilter.md)
```csharp    
//Using a MatchPhraseFilter object
var searchRequest = new SearchRequest("movies");

searchRequest.FulltextFilter = new MatchPhraseFilter("Star Trek 2", "title");

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

#### MatchOpFilter

[[MatchOpFilter]](MatchOpFilter.md)
```csharp
//Using a MatchOpFilter object
var searchRequest = new SearchRequest("movies");

searchRequest.FulltextFilter = new MatchOpFilter("Enterprise test", "title,plot", MatchOpFilter.OperatorEnum.Or);

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```    

### AttrFilter
#### EqualsFilter

[[EqualsFilter]](EqualsFilter.md)

[[Detailed information on equality filters]](https://manual.manticoresearch.com/Searching/Filters#Equality-filters)
```csharp
//Setting the `AttrFilter` property using different attribute filter objects:

//Using an EqualsFilter object
var searchRequest = new SearchRequest("movies");

searchRequest.AttrFilter = new EqualsFilter("year", 2003);

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

#### InFilter

[[InFilter]](InFilter.md)

[[Detailed information on set filters]](https://manual.manticoresearch.com/Searching/Filters#Set-filters)
```csharp
//Using InFilter object
var searchRequest = new SearchRequest("movies");

var inFilter = new InFilter("year", new List<Object> {2001, 2002});
var addValues = new List<Object> {10,11};
inFilter.Values.AddRange(addValues);
searchRequest.AttrFilter = inFilter;

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

#### RangeFilter

[[RangeFilter]](RangeFilter.md)

[[Detailed information on range filters]](https://manual.manticoresearch.com/Searching/Filters#Range-filters)
```csharp
//Using a RangeFilter object
var searchRequest = new SearchRequest("movies");

var rangeFilter = new RangeFilter("year");
rangeFilter.Lte = 2002;
rangeFilter.Gte = 1000;
searchRequest.AttrFilter = rangeFilter;

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

#### GeoDistanceFilter

[[GeoDistanceFilter]](GeoDistanceFilter.md)

[[Detailed information on geo distance filters]](https://manual.manticoresearch.com/Searching/Filters#Geo-distance-filters)
```csharp
//Using a GeoDistanceFilter object
var searchRequest = new SearchRequest("geo");

var geoFilter = new GeoDistanceFilter();
var locAnchor = new GeoDistanceFilterLocationAnchor(10, 20);
geoFilter.LocationAnchor = locAnchor;
geoFilter.LocationSource = "field3,field4";
geoFilter.DistanceType = GeoDistanceFilter.DistanceTypeEnum.Adaptive;
geoFilter.Distance = "100km";
searchRequest.AttrFilter = geoFilter;

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

#### BoolFilter

[[BoolFilter]](BoolFilter.md)

[[Detailed information on Bool queries]](https://manual.manticoresearch.com/Searching/Filters#bool-query)
```csharp
//Setting the `AttrFilter` property using a bool filter object:
var searchRequest = new SearchRequest("movies");

var boolFilter = new BoolFilter();
boolFilter.Must = new List<Object> { new EqualsFilter("year", 2001) };
rangeFilter = new RangeFilter("rating");
rangeFilter.Lte = 20;
boolFilter.Must.Add(rangeFilter);
searchRequest.AttrFilter = boolFilter;

SearchResponse result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);

boolFilter.MustNot = new List<Object> { new EqualsFilter("year", 2001) };
searchRequest.AttrFilter = boolFilter;

result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);

//Using nested bool filters
boolFilter = new BoolFilter();
	
var fulltextFilter = new MatchFilter("Star", "title");
var nestedBoolFilter = new BoolFilter();
nestedBoolFilter.Should = new List<Object> { new EqualsFilter("rating", 6.5), fulltextFilter };
boolFilter.Must = new List<Object> {nestedBoolFilter};
searchRequest.AttrFilter = boolFilter;

result = apiInstance.Search(searchRequest);
Debug.WriteLine(result);
```

#### Using the SearchWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Performs a search
    ApiResponse<SearchResponse> response = apiInstance.SearchWithHttpInfo(searchRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchApi.SearchWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **searchRequest** | [**SearchRequest**](SearchRequest.md) |  |  |

### Return type

[**SearchResponse**](SearchResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **0** | error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

