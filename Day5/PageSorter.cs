using System;
using System.Linq;

namespace Day5;

public class PageSorter(Rule[] rules)
{
    public int[] SortPages(int[] pages)
    {
        var resolvedPages = new int[pages.Length];
        foreach (var page in pages)
        {
            var index = ResolvePageIndex(page, pages);
            resolvedPages[index] = page;
        }

        return resolvedPages;
    }

    private int ResolvePageIndex(int page, int[] allPages)
    {
        var dependentPages = new List<int>();
        AddDependentPages(dependentPages, page);
        
        var index = allPages.Length - 1;
        foreach (var otherPage in allPages.Where(x => x != page))
        {
            if (dependentPages.Contains(otherPage))
                index--;
        }

        return index;
    }

    private void AddDependentPages(List<int> dependentPages, int page)
    {
        foreach (var rule in rules.Where(x => x.PageNumber == page))
        {
            if (dependentPages.Contains(page))
                continue;

            dependentPages.Add(rule.DependentPageNumber);

            AddDependentPages(dependentPages, rule.DependentPageNumber);
        }
    }
}