using System.Buffers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

[assembly: InternalsVisibleTo("Net.Leksi.Pocota.UnitTests")]

namespace Net.Leksi.Pocota.Builder;


internal class TreeWalkerBufferWriter : IBufferWriter<byte>
{
    private byte[] _buf = null!;
    private readonly Stream? _output = null;
    private JsonReaderState _readerState = default;
    private int _offset = 0;

    internal List<Node> Path { get; init; } = new List<Node>();

    internal TreeWalkerBufferWriter(Stream? output)
    {
        _output = output;
    }

    public void Advance(int count)
    {
        //string chunk = Encoding.UTF8.GetString(_buf, _offset, count);
        //Console.WriteLine(chunk);
        if (_output is { })
        {
            _output.Write(_buf, _offset, count);
        }
        Utf8JsonReader reader = new(new ReadOnlySequence<byte>(_buf, 0, _offset + count), false, _readerState);
        while (reader.Read())
        {
            //Console.WriteLine(reader.TokenType);
            switch (reader.TokenType)
            {
                case JsonTokenType.StartArray:
                    Path.Add(new Node { NodeKind = Node.Kind.Array, Count = 0 });
                    break;
                case JsonTokenType.EndArray:
                    Path.RemoveAt(Path.Count - 1);
                    PopProperty();
                    break;
                case JsonTokenType.StartObject:
                    if(Path.Count == 0 || (Path.Count > 0 && Path.Last().NodeKind is not Node.Kind.Property))
                    {
                        Path.Add(new Node { NodeKind = Node.Kind.Object });
                    }
                    IncCount();
                    break;
                case JsonTokenType.EndObject:
                    PopProperty();
                    break;
                case JsonTokenType.PropertyName:
                    Path.Add(new Node { NodeKind = Node.Kind.Property, Name = reader.GetString() });
                    break;
                case JsonTokenType.Comment:
                    reader.GetComment();
                    break;
                case JsonTokenType.Number:
                    Path.Last().IsIncompleteNumber = false;
                    _ = reader.GetInt64();
                    IncCount();
                    PopProperty();
                    break;
                case JsonTokenType.String:
                    _ = reader.GetString();
                    IncCount();
                    PopProperty();
                    break;
                case JsonTokenType.Null:
                    IncCount();
                    PopProperty();
                    break;
                case JsonTokenType.True or JsonTokenType.False:
                    _ = reader.GetBoolean();
                    IncCount();
                    PopProperty();
                    break;
            }
            _readerState = reader.CurrentState;
        }
        _offset += count - (int)reader.BytesConsumed;
        if (_offset > 0)
        {
            Path.Last().IsIncompleteNumber = true;
            Array.Copy(_buf, (int)reader.BytesConsumed, _buf, 0, _offset);
        }
        //PrintPath();
    }

    public Memory<byte> GetMemory(int sizeHint = 0)
    {
        //Console.WriteLine($"GetMemory({sizeHint})");
        if (_buf == null || _buf.Length - _offset < sizeHint)
        {
            byte[]? save = _buf;
            _buf = new byte[_offset + sizeHint];
            if (_offset > 0)
            {
                Array.Copy(save!, 0, _buf, 0, _offset);
            }
        }
        //Console.WriteLine($"new Memory: {_buf.Length}, {_offset}, {sizeHint}");
        return new Memory<byte>(_buf, _offset, sizeHint);
    }

    public Span<byte> GetSpan(int sizeHint = 0)
    {
        throw new NotImplementedException();
    }

    internal void PrintPath()
    {
        foreach(Node node in Path)
        {
            Console.Write($"<{node.NodeKind}:{(node.NodeKind is not Node.Kind.Array ? node.Name : string.Empty)}{(node.NodeKind is Node.Kind.Array ? node.Count : string.Empty)}>");
        }
        Console.WriteLine();
    }

    private void PopProperty()
    {
        if (Path.Count > 0 && (Path.Last().NodeKind is Node.Kind.Property || Path.Last().NodeKind is Node.Kind.Object))
        {
            Path.RemoveAt(Path.Count - 1);
        }
    }

    private void IncCount()
    {
        if (Path.Count > 0 && Path.Last().NodeKind is Node.Kind.Array)
        {
            ++Path.Last().Count;
        }
    }

}

