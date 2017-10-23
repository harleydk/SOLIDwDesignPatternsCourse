using DecoratorPattern;
using System.Diagnostics;

namespace DecoratorPattern_challengeSolved
{
    public static class Program
    {
        /// <summary>
        /// By introducing the MemberDecoratorBase, that 'wraps' a Member-subtype, we can easily add behaviour to a member implementation on demand. This alliviates class explosion, and further gives us the ability to decorate the same class multiple times.
        /// </summary>
        public static void Main()
        {
            IMember clint = Member.CreateMember("Clint Eastwood", 300);
            Debug.WriteLine(clint.GetMemberStatus());

            // Using the decorator pattern, we can now 'wrap' the original object in new clothes.
            // This is why the pattern is sometimes also called the 'wrapper pattern'.
            WithSpecialOfferDecorator specialDealForClint = new WithSpecialOfferDecorator(clint, 100);
            Debug.WriteLine(specialDealForClint.GetMemberStatus());

            WithAnniversaryDecorator anniversaryDealForClint = new WithAnniversaryDecorator(clint);
            Debug.WriteLine(anniversaryDealForClint.GetMemberStatus());

            // we can apply different decorators - wrappers - to the same member.
            WithAnniversaryDecorator anniversaryDealForSpecialOfferClint = new WithAnniversaryDecorator(specialDealForClint);
            Debug.WriteLine(anniversaryDealForSpecialOfferClint.GetMemberStatus());

            // We can easily use the same wrapper twice - twice the special deal!
            // This wasn't so easy before we applied the pattern.
            Member multipleDealsArnold = Member.CreateMember("Arnold Schwarzenegger", 300);
            WithSpecialOfferDecorator firstSpecialDealForArnold = new WithSpecialOfferDecorator(multipleDealsArnold, 500);
            WithSpecialOfferDecorator secondSpecialDealForArnold = new WithSpecialOfferDecorator(firstSpecialDealForArnold, 500);
            WithSpecialOfferDecorator thirdSpecialDealForArnold = new WithSpecialOfferDecorator(secondSpecialDealForArnold, 500);
            Debug.WriteLine(thirdSpecialDealForArnold.GetMemberStatus());
        }
    }
}