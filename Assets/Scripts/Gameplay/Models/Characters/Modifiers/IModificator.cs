using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public interface IModificator
    {
        AsyncReactiveProperty<float> Value { get; }
    }
}