# Kuzu

Kuzu is a command-line application that allows you to interact with your computer in various ways, such as setting the desktop background and chatting with the OpenAI GPT-3 API.

## Features

Kuzu currently supports the following commands:

- `bg <url>`: sets the desktop background to an image specified by a URL
- `chatgpt <prompt>`: sends a prompt to the OpenAI GPT-3 API and returns the response

## Getting started

To use Kuzu, you will need to have .NET 5.0 or later installed on your computer. You can download .NET from the [official website](https://dotnet.microsoft.com/download).

You will also need to have an OpenAI API key to use the `chatgpt` command. You can sign up for an API key on the [OpenAI website](https://beta.openai.com/signup/).

Once you have .NET installed and your API key, you can follow these steps to use Kuzu:

1. Clone the Kuzu repository to your computer.
2. Open a command prompt or terminal window and navigate to the Kuzu project directory.
3. Set your OpenAI API key as an environment variable with the name `OPENAI_API_KEY`. For example, on Windows you can run the command `setx OPENAI_API_KEY "<your-api-key>"`.
4. Run the command `dotnet run` to start Kuzu.
5. Type a command and press Enter to execute it. For example, to set the desktop background to an image at a URL, type `bg <url>` where `<url>` is the URL of the image.

## Contributing

Contributions to Kuzu are welcome! If you would like to contribute code, please fork the repository and submit a pull request. If you would like to report a bug or request a feature, please open an issue on the repository.

## License

Kuzu is released under the [MIT License](LICENSE).
