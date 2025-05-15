📚 Improve Answer API (DDD-Based Design)

This project implements a Improve answer system using Domain-Driven Design (DDD) principles in ASP.NET Core. It supports nested topics (e.g., a tree of educational or categorization subjects).

🧱 Architectural Overview
Layers
Domain Layer: Pure business logic and invariants.

Application Layer: Coordinates domain objects for use cases.

Infrastructure Layer: EF Core and persistence logic.

API Layer: HTTP endpoint definitions and serialization configs.

🛠 Tech Stack
.NET 6+

ASP.NET Core Web API

Entity Framework Core

🚀 Getting Started
Clone the repo

Start the API

Test endpoints like:

GET api/Improve/{studentId}/subtopics – Gets SubTopics with incorrect answers for a student. (For Simplicity Inmemory DB has 1 student with ID as 1)

POST api/Improve/{studentId}/subtopics/{subTopicId}/questions – Gets Questions for a specific SubTopic with incorrect answers for a student. (For Simplicity Inmemory DB has 1 topic and sub topic with ID as 1 each)

POST api/Improve/answer/{answerId} – Updates an answer for a specific question. (For Simplicity Inmemory DB has 1 Question and 1 Answer with ID as 1 each).

💡 Notes
Avoid exposing domain models directly in APIs. Use DTOs in production for control and security.
