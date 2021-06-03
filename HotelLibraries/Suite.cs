using System;


namespace HotelLib
{
    public class Suite
    {
        public enum Type
        {
            Standard, SemiLuxe, Luxe
        }
        public enum Capacity
        {
            Single, Double, Twinn, Family
        }
        private static uint IDcounter = 1;
        private const uint Ar = 5, Pfn = 250;
        public Hotel Hotel { get; private set; }
        public Type RoomType { get; private set; }
        public uint roomID { get; private set; }
        public uint PeopleMaxAmount { get; private set; }
        public uint Area { get; private set; }
        public bool WiFi { get; private set; }
        public bool TVvideoPlayer { get; private set; }
        public bool BigTV { get; private set; }
        public bool AdditionalService { get; private set; }
        public Capacity SuiteCapacity { get; private set; }
        public decimal PriceForNight { get; private set; }
        public bool Free { get; private set; }
        public Suite(Hotel hotel, Type type, Capacity capacity)
        {
            this.Hotel = hotel;
            SuiteFill(type, capacity);
        }
        public Suite(Type type, Capacity capacity)
        {
            this.Hotel = null;
            SuiteFill(type, capacity);
        }
        public void SuiteFill(Type type, Capacity capacity)
        {
            roomID = IDcounter;
            IDcounter++;
            Area = 0;
            PriceForNight = 0;
            Free = true;
            TypeFill(type);
            CapacityFill(capacity);
        }

        public void TypeFill(Type type)
        {
            switch (type)
            {
                case (Type.Standard):
                    Area += 6 * Ar;
                    PriceForNight += 2 * Pfn;
                    WiFi = false;
                    TVvideoPlayer = false;
                    BigTV = false;
                    AdditionalService = false;
                    break;
                case (Type.SemiLuxe):
                    Area += 8 * Ar;
                    PriceForNight += 3 * Pfn;
                    WiFi = true;
                    TVvideoPlayer = true;
                    BigTV = false;
                    AdditionalService = false;
                    break;
                case (Type.Luxe):
                    Area += 10 * Ar;
                    PriceForNight += 4 * Pfn;
                    WiFi = true;
                    TVvideoPlayer = true;
                    BigTV = true;
                    AdditionalService = true;
                    break;
                default:
                    throw new ArgumentException("Wrong type was set while adding a Suite");
            }
        }
        public void CapacityFill(Capacity capacity)
        {
            switch (capacity)
            {
                case (Capacity.Single):
                    Area += 0 * Ar;
                    PriceForNight *= 1;
                    PeopleMaxAmount = 1;
                    SuiteCapacity = Capacity.Single;
                    return;
                case (Capacity.Double):
                    Area += 1 * Ar;
                    PriceForNight *= 2;
                    PeopleMaxAmount = 2;
                    SuiteCapacity = Capacity.Double;
                    return;
                case (Capacity.Twinn):
                    Area += 2 * Ar;
                    PriceForNight = PriceForNight * 2 + Pfn;
                    PeopleMaxAmount = 2;
                    SuiteCapacity = Capacity.Twinn;
                    return;
                case (Capacity.Family):
                    PriceForNight *= 2;
                    Area += 3 * Ar;
                    PeopleMaxAmount = 5;
                    SuiteCapacity = Capacity.Family;
                    return;
                default:
                    throw new ArgumentException("Wrong capacity was set while adding a Suite");
            }
        }
        
        public void HoldSuite()
        {
            Free = false;
        }
        public void FreeSuite()
        {
            Free = true;
        }
        
    }
}
