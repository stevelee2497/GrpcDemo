﻿using Grpc.Net.Client;
using System.Text.Json;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7120");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);

var userId = "user - 1";
var todoClient = new Todo.TodoClient(channel); //etcd
var todoItems = await todoClient.GetTodoItemsAsync(new TodoItemsRequest { UserId = userId });
Console.WriteLine($"Todo list for user: {userId}, items: {JsonSerializer.Serialize(todoItems)}");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();