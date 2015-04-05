using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevenshtienAlgorithm;
using Simila.Core.Levenstein.Mistakes;

namespace Simila.Core.Levenstein.CostResolvers
{
    public class CostResolverFactory
    {
        public class Character
        {
            private CharacterCostResolver _resolver;

            private Character(CharacterCostResolver resolver)
            {
                _resolver = resolver;
            }
            public static Character Init()
            {
                return new Character(new CharacterCostResolver(numericInsertionCost: .5, isCaseSensitive: false));
            }

            public Character AddEnglishCommonMistakes()
            {
                if (File.Exists("CommonEnglishCharacterMistakes.xml"))
                {
                    var repo = MistakesFactory.FromXml("CommonEnglishCharacterMistakes.xml");
                    var mistakes = repo.GetMistakes();

                    foreach (var mistake in mistakes)
                    {
                        _resolver.SetCost(mistake.Left, mistake.Right, mistake.Cost);
                    }
                }
                
                return this;
            }

            public Character AddPersianCommonMistakes()
            {
                _resolver.SetCost('ر', 'ز', 0.5);
                _resolver.SetCost('س', 'ش', 0.5);
                _resolver.SetCost('ی', 'ي', 0.0);
                _resolver.SetCost('ی', 'ي', 0.0);
                _resolver.SetCost('ک', 'ك', 0.0);
                _resolver.SetCost('ک', 'گ', 0.5);
                _resolver.SetCost('آ', 'ل', 0.75);
                _resolver.SetCost('د', 'ذ', 0.5);

                return this;
            }

            public CharacterCostResolver Build()
            {
                return _resolver;
            }

            public static CharacterCostResolver Default()
            {
                return Init()
                    .AddEnglishCommonMistakes()
                    .AddPersianCommonMistakes()
                    .Build();
            }
        }
    }
}
