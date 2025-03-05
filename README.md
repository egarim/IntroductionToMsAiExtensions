

## Table of Contents
- [1-ChatClientAbstractions](#1-chatclientabstractions)
- [2-ChatCompletions](#2-chatcompletions)
- [3-ChatMessage](#3-chatmessage)
- [4-StructureOutput](#4-structureoutput)
- [5-Pipelines](#5-pipelines)
- [6-EmbeddingsTensorsAndSearch](#6-embeddingstensorsandsearch)
- [7-ToolsAndFunctions](#7-toolsandfunctions)

### 1-ChatClientAbstractions
**Focus**: Demonstrates chat client abstraction with OpenAI GPT-4 and Ollama Phi3.

**Key Components**:
- Uses `Microsoft.Extensions.AI` and `OpenAI` namespaces.
- Includes `IChatClient CurrentClient`, `OpenAiModelId`, and `OllamaModelId`.
- Asynchronous `Main` method initializes with `GetChatClientOllamaImp`.

**Demonstrations**:
- Switching between AI models.
- Sending prompts and displaying responses.

### 2-ChatCompletions
**Focus**: Uses OpenAI GPT-4 for chat completions, including token limiting.

**Key Components**:
- Uses `Microsoft.Extensions.AI` and `OpenAI` namespaces.
- Includes `IChatClient CurrentClient` and `OpenAiModelId`.
- `Main` method demonstrates `ChatOptions` for token limits.

**Demonstrations**:
- Initialization of the chat client.
- Sending prompts and receiving responses.
- Controlling output with `ChatOptions`.

### 3-ChatMessage
**Focus**: Handles chat history and messages, including image attachments.

**Key Components**:
- Manages chat history with `ChatMessage`.
- Demonstrates attaching images to messages.

**Demonstrations**:
- Creating and managing chat history.
- Handling messages with additional content like images.

### 4-StructureOutput
**Focus**: Analyzes images and returns structured data using OpenAI GPT-4.

**Key Components**:
- Reads images (Cats.jpg, Puppies.jpg, Robots.jpg) as byte arrays.
- Expects structured output of type `CatCollectionDescription`.

**Demonstrations**:
- Sending prompts with images.
- Receiving and displaying structured responses.

### 5-Pipelines
**Focus**: Manages multiple completions with configurations like function invocation and rate limiting.

**Key Components**:
- Configures chat client with `UseFunctionInvocation()`, `UserLanguage("spanish")`, and rate limiting.

**Demonstrations**:
- Generating multiple completions.
- Applying language settings and rate limiting.

### 6-EmbeddingsTensorsAndSearch
**Focus**: Uses embeddings and tensor operations for similarity searches.

**Key Components**:
- Uses `System.Numerics.Tensors` and `OllamaEmbeddingGenerator`.
- Calculates cosine similarity for text embeddings.

**Demonstrations**:
- Generating embeddings for text.
- Performing similarity searches and displaying results.

### 7-ToolsAndFunctions
**Focus**: Integrates tools and custom functions, including shopping cart operations.

**Key Components**:
- Uses `AIFunctionFactory` for tools like getting prices and adding items.
- Configured for function invocation.

**Demonstrations**:
- Continuous user interaction in a chat loop.
- Integrating custom functions for enhanced chat experience.

## Project Summary
| Project ID               | Focus Area                          | Key Features                                      |
|--------------------------|-------------------------------------|--------------------------------------------------|
| 1-ChatClientAbstractions | Chat client abstraction             | Switching between OpenAI GPT-4 and Ollama Phi3   |
| 2-ChatCompletions        | Chat completions with OpenAI GPT-4  | Token limiting, response generation              |
| 3-ChatMessage            | Chat history and message handling   | Managing history, attaching images               |
| 4-StructureOutput        | Image analysis and structured output| Analyzing images, structured data output         |
| 5-Pipelines              | Multiple completions and configs    | Function invocation, language settings, rate limiting |
| 6-EmbeddingsTensorsAndSearch | Embeddings and similarity searches | Tensor operations, cosine similarity searches    |
| 7-ToolsAndFunctions      | Tools and custom functions          | Integrating functions, shopping cart operations  |
```

This README file is structured to provide a clear and comprehensive overview of the projects in your repository. It includes an introduction, setup instructions, a table of contents, detailed project descriptions, and a summary table for quick reference. The content is formatted using Markdown for better readability and navigation.

You can copy and paste this content directly into your repository's README file. If you need any further adjustments or additional sections, feel free to let me know!