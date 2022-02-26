namespace StudentTesting.Application.Utils
{

    public partial class EditerUserViewModel
    {
        public readonly struct FieldPropertyRelation
        {
            public readonly string Property;
            public readonly string Field;

            public FieldPropertyRelation(string property, string field)
            {
                Property = property;
                Field = field;
            }
        }
    }
}
