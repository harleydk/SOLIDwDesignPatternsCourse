using DecoratorPattern;
using System.Diagnostics;

namespace DecoratorPattern_challenge
{
    public static class Program
    {
        public static void Main()
        {
            // challenge: use the decorator pattern to solve the problem of potential class explosion as per the 'problem' project.

            /* start by implementing the MemberDecoratorBase abstract class, that
                - implements IMember,
                - takes an IMember in its constructor and holds it is a field,
                --and relegates to this in its virtual implementations of the interface
             */

            IMember clint = new Member()
            {
                Name = "Clint Eastwood",
                Points = 300
            };
            Debug.WriteLine(clint.GetMemberStatus());

            /*#
            // Now we need an enhanced member, so we override the Member into a SpecialOfferMember class.
            SpecialOfferMember specialDealForClint = new SpecialOfferMember(extraPoints: 100)
            {
                Name = "Clint Eastwood",
                Points = 300,
            };
            Debug.WriteLine(specialDealForClint.GetMemberStatus());

            // Now we need an anniversary member, so we override the Member class into an
            AnniversaryMember clintWithAnniversary = new AnniversaryMember()
            {
                Name = "Clint Eastwood",
                Points = 300
            };
            Debug.WriteLine(clintWithAnniversary.GetMemberStatus());

            //? Quickly leads to class explosion.
            // What if we want Clint to be _both_ special-deal recipient _and_ administrator? (code below)
            SpecialOfferAnniversaryMember clintTheAdminAndSpecialDealRecipient =
                new SpecialOfferAnniversaryMember(100)
                {
                    Name = "Clint Eastwood",
                    Points = 300
                };
            Debug.WriteLine(clintTheAdminAndSpecialDealRecipient.GetMemberStatus());
            */
        }
    }
}