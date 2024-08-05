To Run application:
Should just be able build and Swagger UI will appear.
You can then create a customer and use the other end points.

One thing to notice is when creating a customer swagger will say Id=0 and you can add what ever you like but EF will give the Id so it'll be sequential but use the Get method if you lose track. This is an issue but I've spent enough time on this for an interview.

Assumptions/Design decisions 
There's so much to improve on this with more time.
I started thinking I would use Domain driven design and then thought for what it is there's not much point on implementing application layers and command query segregation so sort of started that way and didn't stick to tdd as I should have (months rustiness of not coding)

The validation isn't really tested and could be much better
Solution needs more controllers and tests for other entities but thought it would be repetitive for a interview test task 

Customer Could be implemented as Aggregate route

Overall not overly happy with it, I wouldn't submit that for PR as done at all but thought it showed enough for this task


