# About TextComposerLib

> In science, if you don’t do it, somebody else will. Whereas in art, if Beethoven didn’t compose the ‘Ninth Symphony,’ no one else before or after is going to compose the ‘Ninth Symphony’ that he composed; no one else is going to paint ‘Starry Night’ by van Gogh. — Neil deGrasse Tyson.

The final stage in any compiler is [code generation](https://en.wikipedia.org/wiki/Code_generation_(compiler)) from some intermediate representation of the input source code. This stage is the most demanding for creativity because it relies on designing and implementing many optimizations to generate target code suitable for its specific consumer. Traditional compilers typically generate machine code for native hardware or bytecode for virtual machine frameworks. This form of code is machine-oriented, cold and repetitive code not intended for reading or understanding by humans. GMac, being a DSL based source-to-source compiler, produces programmer-oriented textual source code in some high-level human-readable language. The difference between designing the code generator of any typical compiler vs. the code generator of a system like GMac is similar to the difference between designing a machine that creates mechanical parts and designing a tool-set for an artist.

_**TextComposerLib**_ is a set of .NET classes and interfaces specifically designed for structured text generation. The most important kind of text generation is the composition of software code from a suitable data source. _**TextComposerLib**_ contains many integrating classes to implement structured text generation tasks using various methods of procedural composition of text; ranging from simple text concatenation to complex code library construction.

To use _**TextComposerLib**_ you need to have a Windows 7 or later operating system and the .NET Framework version 4.0\. You naturally need a .NET development environment like Visual Studio 2010 or later to use _**TextComposerLib**_ in your .NET projects.

You can find the latest version of _**TextComposerLib**_ source code on GitHub here: [https://github.com/ga-explorer/TextComposerLib](https://github.com/ga-explorer/TextComposerLib)

* * *

## TextComposerLib Features

*   A wide range of structured procedural text composition methods adopting the [Linq to objects](http://www.blackwasp.co.uk/LinqToObjectsTutorial.aspx) capabilities of the .NET framework.
*   Simple text composition by concatenation of lists of strings as extension methods.
*   Text composition from common data structures like stacks, queues, and priority queues.
*   Text composition from string mappings and transforms for more complex applications.
*   Linear text composition component resulting in well-formatted text documents including indentation management and precise selection of each line of text in the final document.
*   Template-based text composition using parametric substitution text templates. This is one of the more common methods of code generation.
*   A component of text injection inside a bulk of mostly-fixed text document. This is suitable for code injection within marked regions in the code file.
*   The composition of text from expression trees suitable for creating [un-parsers](https://en.wikipedia.org/wiki/Unparser) (systems that can generate text by visiting a tree-like structure). This is a key component in source-to-source compilers like GMac.
*   A powerful composition component for creating text files nested inside arbitrary directories. This component can be used with other components to create any desired structure of text files or code files.
*   A powerful logging component capable of reporting events and progress of long-running computational processes at any desired level of detail including errors, warnings, start and end of intermediate steps, etc.
*   A full-featured .NET wrapper for the [GraphViz](http://www.graphviz.org/) graph visualization software. This component includes a powerful AST representation of GraphViz dot code that can procedurally create graphs, nodes, edges, subgraphs, and clusters, in addition to managing all their properties and attributes using managed .NET properties and methods. The component also includes a simple to use interface for rendering the generated graph from within the TextComposerLib itself provided the executable GraphViz is present on the same computer.
*   A capability for creating full libraries of structured code text documents using a well-designed code library generator base class. This class can be inherited to implement arbitrarily complex code library generators for any application including source-to-source compilers like GMac.

* * *

## Why call it a Composer, not a Generator?

If we lookup the verb _**compose**_ in the [Merriam-Webster online dictionary](https://www.merriam-webster.com/dictionary/compose) we’ll find the following meanings:

1.  **A) to form by putting together** : fashion; ‘a committee composed of three representatives’  
    **B) to form the substance of** : constitute; ‘composed of many ingredients’  
    **C) to produce (as columns or pages of type) by composition**
2.  **A) to create by mental or artistic labor** : produce; ‘compose a sonnet’  
    **B) to formulate and write (a piece of music)** : to compose music for
3.  **to deal with or act on so as to reduce to a minimum** ‘compose their differences’
4.  **to arrange in proper or orderly form**
5.  **to free from agitation** : calm, settle ‘composed himself’

My view of coding is a form of:

> Creative composition of highly structured, human-understandable, and machine-compilable text holding all the meanings of the verb _**compose**_ stated above.

To me writing code is not just about execution efficiency or blind implementation of algorithms; writing code is fundamentally artistic such that no two skilled software developers may produce the same code for a single problem. Like there can be no machine that may creatively produce music or paintings, there can be no single code generator that can, by itself, write human-understandable code with all its rich content of information, creativity, and beauty. Nevertheless, we can certainly make many smaller tool sets to help the skilled code developer layout code in the way humanly and creatively desired, while automatically generating machine-oriented code from the intermediate representation to free the _**coding artist**_ from its repetitive cold nature.

TextComposerLib is the text generation toolset specifically created for GMac, but independently usable otherwise. In [this online guide](https://gmac-guides.netlify.com/index.php/textcomposerlib-guide/), we give a description of the main functionality of this toolset through examples. TextComposerLib consists of several _**composers**_ each having unique capabilities and intended use. We will illustrate many of them in this guide from the most simple to the more complex.  The TextComposerLib composers can easily and flexibly be integrated to produce text files with arbitrary internal (i.e. text related) and external (i.e. folders related) structure. The quality of the generated text is, however, a direct expression of how the toolset is creatively used by the code designer. In my experience with GMac, in the hands of a good coding artist, TextComposerLib is a very helpful tool. This guide is not intended to give the full details of all classes in TextComposerLib but is a means of illustrating the general behavior of its main composers. Many other samples can be found under the TextComposerLibSamples project inside the main solution.
