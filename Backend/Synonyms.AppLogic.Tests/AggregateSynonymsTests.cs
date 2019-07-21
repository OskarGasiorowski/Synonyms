using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Synonyms.AppLogic.Tests
{
    [TestFixture]
    public class AggregateSynonymsTests
    {
        [Test,TestCaseSource(typeof(SynonymsTestCase),nameof(SynonymsTestCase.TestCases))]
        public void Test(IReadOnlyList<SynonymsDto> input, IReadOnlyList<SynonymsDto> expectedResult)
        {
            var result = input.AggregateSynonyms();
            Assert.That(IsOk(result, expectedResult), Is.True);
        }

        private static bool IsOk(IReadOnlyList<SynonymsDto> result, IReadOnlyList<SynonymsDto> expectedResult)
        {
            foreach (var expected in expectedResult)
            {
                var syn = result.Single(res => res.Term == expected.Term);
                var isOk = expected.Synonyms.OrderBy(s => s).SequenceEqual(syn.Synonyms.OrderBy(s => s));

                if (!isOk)
                    throw new Exception($"Expected: {expected.Term} - {string.Join(',', expected.Synonyms)} but found {syn.Term} - {string.Join(',', syn.Synonyms)}");
            }

            return true;
        }
    }

    public static class SynonymsTestCase
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(
                    new List<SynonymsDto>
                    {
                        new SynonymsDto
                        {
                            Term = "Computer",
                            Synonyms = new List<string>
                            {
                                "Laptop"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Computer",
                            Synonyms = new List<string>
                            {
                                "Workstation"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Computer",
                            Synonyms = new List<string>
                            {
                                "Pc", "Netbook"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Notebook",
                            Synonyms = new List<string>
                            {
                                "Computer", "Portable-computer"
                            }
                        }
                    },
                    new List<SynonymsDto>
                    {
                        new SynonymsDto
                        {
                            Term = "Computer",
                            Synonyms = new List<string>
                            {
                                "Laptop", "Notebook", "Workstation", "Pc", "Netbook"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Laptop",
                            Synonyms = new List<string>
                            {
                                "Computer"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Workstation",
                            Synonyms = new List<string>
                            {
                                "Computer"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Pc",
                            Synonyms = new List<string>
                            {
                                "Computer"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Netbook",
                            Synonyms = new List<string>
                            {
                                "Computer"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Notebook",
                            Synonyms = new List<string>
                            {
                                "Computer", "Portable-computer"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Portable-computer",
                            Synonyms = new List<string>
                            {
                                "Notebook"
                            }
                        },
                    }
                );
                
                yield return new TestCaseData(
                    new List<SynonymsDto>
                    {
                        new SynonymsDto
                        {
                            Term = "Computer",
                            Synonyms = new List<string>
                            {
                                "PC", "Device"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Laptop",
                            Synonyms = new List<string>
                            {
                                "Computer", "Device"
                            }
                        }
                    },
                    new List<SynonymsDto>
                    {
                        new SynonymsDto
                        {
                            Term = "Computer",
                            Synonyms = new List<string>
                            {
                                "PC", "Laptop", "Device"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Laptop",
                            Synonyms = new List<string>
                            {
                                "Computer", "Device"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "Device",
                            Synonyms = new List<string>
                            {
                                "Laptop", "Computer"
                            }
                        },
                        new SynonymsDto
                        {
                            Term = "PC",
                            Synonyms = new List<string>
                            {
                                "Computer"
                            }
                        }
                    }    
                );
            }
        }
    }
}