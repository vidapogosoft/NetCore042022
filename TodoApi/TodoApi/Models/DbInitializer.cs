namespace TodoApi.Models
{
    public static class DbInitializer
    {
        public static void Initialize(TodoContext context)
        {
            // Look for any students.
            if (context.TodoItems.Any())
            {
                return;   // DB has been seeded
            }

            var datos = new TodoItem[]
            {
                new TodoItem{Id=1,NombreTarea="Tarea 1",EstaCompleto=true},
                new TodoItem{Id=2,NombreTarea="Tarea 2",EstaCompleto=false},
                new TodoItem{Id=3,NombreTarea="Tarea 3",EstaCompleto=true},
                new TodoItem{Id=4,NombreTarea="Tarea 4",EstaCompleto=false}
                
            };

            context.TodoItems.AddRange(datos);
            context.SaveChanges();

        }
    }
}