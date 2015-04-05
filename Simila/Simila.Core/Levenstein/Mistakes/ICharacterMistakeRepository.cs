using System.Collections.Generic;

namespace Simila.Core.Levenstein.Mistakes
{
    public interface ICharacterMistakeRepository
    {
        List<CharacterMistake> GetMistakes();
    }
}