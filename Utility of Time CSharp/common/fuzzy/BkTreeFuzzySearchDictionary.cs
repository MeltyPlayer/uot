using System.Collections.Generic;
using System.Linq;

using FastFuzzyStringMatcher;

namespace UoT.common.fuzzy {
  public class BkTreeFuzzySearchResult<T> : IFuzzySearchResult<T> {
    public T AssociatedData { get; set; }
    public float MatchPercentage { get; set; }
  }

  public class BkTreeFuzzySearchDictionary<T> : IFuzzySearchDictionary<T> {
    private readonly StringMatcher<T> impl_ = new StringMatcher<T>();

    public void Add(string keyword, T associatedData)
        => this.impl_.Add(keyword, associatedData);

    public IEnumerable<IFuzzySearchResult<T>> Search(string keyword, float matchPercentage)
      => this.impl_.Search(keyword, matchPercentage)
             .Select(searchResult => new BkTreeFuzzySearchResult<T> {
                 AssociatedData = searchResult.AssociatedData,
                 MatchPercentage = searchResult.MatchPercentage
             });
  }
}