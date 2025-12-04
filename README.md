
## Environment Variables

The backend requires several environment variables for configuration. Replace the placeholder values with your own secure values before running the application.

-------------------------------------------------------------------------------------------------------------------------------------------------
| Variable                                 | Description                                   | Example / Placeholder Value                        |
| ---------------------------------------- | --------------------------------------------- | ---------------------------------------------------|
| `Jwt__Key`                               | Secret key used to sign JWT tokens            | `YOUR_SECRET_KEY_HERE`                             |
| `Jwt__Issuer`                            | Issuer of the JWT tokens                      | `myapp-dev`                                        |
| `ConnectionStrings__DefaultConnection`   | Connection string for the PostgreSQL database | `YOUR_DATABASE_URL_HERE`                           |
| `Cors__AllowedOrigins`                   | Allowed frontend origins for CORS             | `http://localhost:4200,http://localhost:5069`      |
-------------------------------------------------------------------------------------------------------------------------------------------------

## Backend Test Verification Checklist

The following table summarizes all backend functionality tests conducted using Postman to ensure proper authentication, authorization, and CRUD operations:

-------------------------------------------------------------------------------------------------------------------------------------------------
| Feature                        | What Was Tested                                             | Result / Confirmation                          |
| ------------------------------ | ----------------------------------------------------------- | -----------------------------------------------|
| **User Registration**          | Registered new users via `POST /api/auth/register`          | ✅ Success, unique emails enforced             |
| **User Login**                 | Logged in with valid credentials via `POST /api/auth/login` | ✅ Success, JWT token returned                 |
| **JWT Token Handling**         | Token returned as HttpOnly cookie                           | ✅ Success, cookie set in Postman              |
| **Token Expiration**           | Verified token expires after 3 hours                        | ✅ Confirmed in Postman                        |
| **Authentication Enforcement** | Accessed protected endpoints without token                  | ✅ Blocked with 401 Unauthorized               |
| **Books CRUD**                 | Created, updated, deleted books as authenticated user       | ✅ Success for all operations                  |
| **Books Ownership**            | Tried updating/deleting another user’s book                 | ✅ Forbidden (403) confirmed                   |
| **Quotes CRUD**                | Created, updated, deleted quotes as authenticated user      | ✅ Success for all operations                  |
| **Quotes Ownership**           | Tried accessing/editing another user’s quotes               | ✅ Forbidden (403) confirmed                   |
| **Quotes Limit**               | Fetched all quotes via `GET /api/quotes`                    | ✅ Only 5 most recent quotes returned per user |
| **Per-User Data Isolation**    | Verified each user only sees their own books/quotes         | ✅ Confirmed with multiple accounts in Postman |
-------------------------------------------------------------------------------------------------------------------------------------------------



## Professional Enhancements (Optional)

The backend is functional and meets the test requirements. To make it more robust and production-ready, the following improvements could be considered:

- **Rate limiting**: Prevent brute-force attacks by limiting the number of login attempts per user or IP address.  
- **Request throttling**: Control API usage per user or IP to prevent abuse or denial-of-service attacks.  
- **Password policies and account lockout**: Enforce strong passwords and temporarily lock accounts after repeated failed login attempts.  
- **Refresh tokens**: Implement refresh tokens to improve session management and enhance user experience.  
- **Email verification**: Verify new user emails to reduce fake accounts and improve security.  
- **Input validation**: Ensure all incoming data (e.g., registration fields, book details, quotes) are properly formatted, within acceptable lengths, and of the correct type.  
- **SQL injection protection**: While Entity Framework automatically parameterizes queries, always ensure that any raw SQL or user input is properly sanitized to prevent SQL injection.  
- **Logging and monitoring**: Track application activity, errors, and security events to support maintenance and auditing.  




