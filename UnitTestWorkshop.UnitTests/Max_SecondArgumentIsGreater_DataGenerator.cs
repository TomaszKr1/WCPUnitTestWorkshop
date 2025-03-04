using System.Collections;

namespace UnitTestWorkshop.UnitTests;

public class MaxSecondArgumentIsGreaterDataGenerator : TheoryData<int, int, int>
{
    public MaxSecondArgumentIsGreaterDataGenerator()
    {
        Add(3, 5, 5);
        Add(3, 0, 3);
        Add(0, 5, 5);
        Add(5, 3, 5);
        Add(0, 3, 3);
        Add(5, 0, 5);
        Add(3, 3, 3);
        Add(0, 0, 0);
        
        // AddRange(new TheoryData<int, int, int>
        // {
        //     {3, 5, 5},
        //     {3, 0, 3},
        //     {0, 5, 5},
        //     {5, 3, 5},
        //     {0, 3, 3},
        //     {5, 0, 5},
        //     {3, 3, 3},
        //     {0, 0, 0}
        // });
    }
}


public class MaxSecondArgumentIsGreaterDataGeneratorObject : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return ["dupa", 5, 5];
        yield return [3, 0, false];
        yield return [0, 5, 5];
        yield return [5, 3d, 5];
        yield return [0f, 3, 3];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}