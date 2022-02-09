<h1>C# Midterm Starter</h1>

**Environment:**

- The CSV file is in the wwwroot folder.

- Sqlite DB Connection string is in appsettings.json

**Controllers:**

- Create a controller for the entity (ex. Student)

```console
dotnet aspnet-codegenerator controller -name StudentsController -async -m Student -dc ApplicationDbContext -outDir Controllers -sqlite
```

- Update the ChartsController according to the task.

**Migrations and creating DB:**

```console
dotnet ef migrations add M1 -o Data/Migrations
```

```console
dotnet-ef database update
```

**Docker:**

- Publish the app

```console
./pblsh.sh
```

- Create the image and run the container locally to test it (Accessible on http://localhost:5000/)

```console
docker compose up
```

- After:

```console
docker compose down
```

- Create and tag the image for sending it to Docker hub

```console
docker build --tag dotnetmidterm:1.0.0 .
```

- Login to your Docker account through terminal

```console
docker login --username=[YOUR_USERNAME]
```

- Tag your image with your DockerID

```console
docker tag dotnetmidterm:1.0.0 [YOUR_USERNAME]/dotnetmidterm:1.0.0
```

- Push the image to DockerHub

```console
docker push [YOUR_USERNAME]/dotnetmidterm:1.0.0
```

- To run you image from DockerHub, remove the image locally and run the following command

```console
docker run -d -p 8888:80 [YOUR_USERNAME]/dotnetmidterm:1.0.0
```
