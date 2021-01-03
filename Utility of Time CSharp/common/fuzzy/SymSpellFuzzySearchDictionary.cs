using System;
using System.Collections.Generic;
using System.Linq;

namespace UoT.common.fuzzy {
  public class SymSpellFuzzySearchResult<T> : IFuzzySearchResult<T> {
    public T AssociatedData { get; set; }
    public float MatchPercentage { get; set; }
  }

  public class SymSpellFuzzySearchDictionary<T> : IFuzzySearchDictionary<T> {
    /**
     * var maxEditDistance =
     * (int) Math.Floor(minMatchPercentage * .01 * this.impl_.MaxLength);
     */
    private const int MAX_EDIT_DISTANCE = 8;

    private readonly SymSpell impl_ =
        new SymSpell(0,
                     SymSpellFuzzySearchDictionary<T>.MAX_EDIT_DISTANCE,
                     SymSpellFuzzySearchDictionary<T>.MAX_EDIT_DISTANCE + 1);

    private readonly IDictionary<string, T> associatedData_ =
        new Dictionary<string, T>();

    public void Add(string keyword, T associatedData) {
      // TODO: Support token frequency?
      this.impl_.CreateDictionaryEntry(keyword, 1);
      this.associatedData_.Add(keyword, associatedData);
    }

    public IEnumerable<IFuzzySearchResult<T>> Search(
        string keyword,
        float minMatchPercentage) {
      // TODO: Use minMatchPercentage.
      return this
             .impl_.Lookup(keyword,
                           SymSpell.Verbosity.All,
                           SymSpellFuzzySearchDictionary<T>.MAX_EDIT_DISTANCE)
             .Select(suggestItem => {
               var matchedKeyword = suggestItem.term;
               var matchPercentage = (1 -
                                      (1.0 * suggestItem.distance) /
                                      Math.Max(matchedKeyword.Length,
                                               keyword.Length)) *
                                     100;

               return new SymSpellFuzzySearchResult<T> {
                   AssociatedData = this.associatedData_[matchedKeyword],
                   MatchPercentage = (int) Math.Ceiling(matchPercentage)
               };
             });
    }
  }
}