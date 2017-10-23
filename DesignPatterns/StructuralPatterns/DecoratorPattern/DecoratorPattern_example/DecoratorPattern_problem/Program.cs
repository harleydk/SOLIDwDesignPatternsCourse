using DecoratorPattern;
using System.Diagnostics;

namespace DecoratorPattern_problem
{
    public sealed class Program
    {
        /// <summary>
        /// The below scenario is of a deals-website. As members login, they're assigned to an implementation of a Member-subtype, if they're eligible for a particular promotion. Thus we can continously add Member-subtypes to suit our requirements, but this will quickly lead to class explosion. What we're really looking to do is add _behaviour_, not types.
        /// </summary>
        public static void Main()
        {
            IMember clint = new Member()
            {
                Name = "Clint Eastwood",
                Points = 300
            };
            Debug.WriteLine(clint.GetMemberStatus());

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

            // Quickly leads to class explosion.
            // What if we want Clint to be _both_ special-deal recipient _and_ administrator? (code below)
            SpecialOfferAnniversaryMember clintTheAdminAndSpecialDealRecipient =
                new SpecialOfferAnniversaryMember(100)
                {
                    Name = "Clint Eastwood",
                    Points = 300
                };
            Debug.WriteLine(clintTheAdminAndSpecialDealRecipient.GetMemberStatus());
        }
    }
}