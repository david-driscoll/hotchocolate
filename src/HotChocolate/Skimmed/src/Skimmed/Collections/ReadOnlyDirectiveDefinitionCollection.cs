using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace HotChocolate.Skimmed;

public sealed class ReadOnlyDirectiveDefinitionCollection : IDirectiveDefinitionCollection
{
    private readonly OrderedDictionary<string, DirectiveDefinition> _types;

    private ReadOnlyDirectiveDefinitionCollection(IEnumerable<DirectiveDefinition> directives)
    {
        ArgumentNullException.ThrowIfNull(directives);
        _types = directives.ToOrderedDictionary(t => t.Name);
    }

    public int Count => _types.Count;

    public bool IsReadOnly => false;

    public DirectiveDefinition this[string name] => _types[name];

    public bool TryGetDirective(string name, [NotNullWhen(true)] out DirectiveDefinition? definition)
        => _types.TryGetValue(name, out definition);

    public void Insert(int index, DirectiveDefinition definition)
        => ThrowReadOnly();

    public bool Remove(string name)
    {
        ThrowReadOnly();
        return false;
    }

    public void RemoveAt(int index)
        => ThrowReadOnly();

    public void Add(DirectiveDefinition item)
        => ThrowReadOnly();

    public bool Remove(DirectiveDefinition item)
    {
        ThrowReadOnly();
        return false;
    }

    public void Clear() => ThrowReadOnly();

    [DoesNotReturn]
    private static void ThrowReadOnly()
        => throw new NotSupportedException("Collection is read-only.");

    public bool ContainsName(string name)
        => _types.ContainsKey(name);

    public int IndexOf(DirectiveDefinition definition)
    {
        if (definition == null)
        {
            throw new ArgumentNullException(nameof(definition));
        }

        return IndexOf(definition.Name);
    }

    public int IndexOf(string name)
        => _types.IndexOf(name);

    public bool Contains(DirectiveDefinition item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (_types.TryGetValue(item.Name, out var itemToDelete) &&
            ReferenceEquals(item, itemToDelete))
        {
            return true;
        }

        return false;
    }

    public void CopyTo(DirectiveDefinition[] array, int arrayIndex)
    {
        foreach (var item in _types)
        {
            array[arrayIndex++] = item.Value;
        }
    }

    public IEnumerator<DirectiveDefinition> GetEnumerator()
        => _types.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    public static ReadOnlyDirectiveDefinitionCollection Empty { get; } = new(Array.Empty<DirectiveDefinition>());

    public static ReadOnlyDirectiveDefinitionCollection From(IEnumerable<DirectiveDefinition> values)
        => new(values);
}
