# YSAP - Artificial Neural Network Simulator 🧠

[![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.8-512BD4?style=for-the-badge&logo=.net)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)](https://visualstudio.microsoft.com/)

**YSAP (Yapay Sinir Ağı Projesi)** is a Windows Forms application built with C# and the .NET Framework. It serves as a hands-on educational tool for demonstrating the principles of a feedforward artificial neural network. The application allows users to train a custom-built neural network on a given dataset and then test its predictive capabilities.

---

## 📖 Table of Contents

- [📌 Project Abstract](#-project-abstract)
- [🧠 The Neural Network Core](#-the-neural-network-core)
- [✨ Application Features](#-application-features)
- [🛠️ Technology Stack](#️-technology-stack)
- [💾 Data & File System](#-data--file-system)
- [🚀 How to Run](#-how-to-run)
  - [Prerequisites](#prerequisites)
  - [Configuration & Setup](#configuration--setup)
- [🤝 Contributing](#-contributing)

---

## 📌 Project Abstract

Artificial Neural Networks (ANNs) are the foundation of modern machine learning. This project provides a practical, from-scratch implementation of a simple feedforward neural network to demystify its core mechanics. Instead of relying on high-level machine learning libraries, **YSAP** showcases the fundamental mathematics and logic behind network training, including the backpropagation algorithm.

The application provides a graphical user interface to:
1.  Configure the network's hyperparameters (learning rate, momentum, epochs).
2.  Initiate and monitor the training process using a local dataset.
3.  Save the trained network weights.
4.  Use the trained model to make predictions on new, unseen data inputs.

It is designed as both a functional tool and an educational resource for anyone interested in the practical implementation of neural networks.

---

## 🧠 The Neural Network Core

The heart of the application is a custom-coded neural network class (`YapaySinirAgi`). Its architecture and learning algorithm are as follows:

-   **Architecture:** A simple feedforward network with three layers:
    -   An **Input Layer**
    -   A single **Hidden Layer**
    -   An **Output Layer**
-   **Activation Function:** The Sigmoid function is used for neuron activation, which squashes output values between 0 and 1.
-   **Training Algorithm:** The network is trained using the **Backpropagation** algorithm. During each epoch, the network calculates the error between its prediction and the actual target, then propagates this error backward to adjust the weights of the hidden and output layers.
-   **Hyperparameters:** The user can control key aspects of the training process through the UI:
    -   **Learning Rate (`Öğrenme Katsayısı`):** Controls the step size for weight adjustments.
    -   **Momentum:** Helps the network to avoid local minima and speed up convergence.
    -   **Epoch Count (`Epoch Sayısı`):** The number of times the entire training dataset is passed through the network.

---

## ✨ Application Features

The main window (`Form1.cs`) provides a simple yet powerful interface for interacting with the neural network.

-   **Training Module:**
    -   Load a training dataset from a local text file (`egitim_veriseti.txt`).
    -   Set the learning rate, momentum, and number of epochs.
    -   Click the **"Eğit" (Train)** button to start the training process.
    -   The application saves the resulting weights for the hidden and output layers into separate text files upon completion.
-   **Testing Module:**
    -   After training, the application automatically loads the saved weights.
    -   Users can input new data points into the designated input fields.
    -   Click the **"Test Et" (Test)** button to run the input through the trained network and see the predicted output.
-   **Data Display:** All input data, network parameters, and outputs are clearly displayed in text boxes for easy inspection and analysis.

---

## 🛠️ Technology Stack

-   **Framework:** .NET Framework 4.8
-   **Language:** C#
-   **User Interface:** Windows Forms (WinForms)
-   **Development Environment:** Visual Studio

---

## 💾 Data & File System

The application relies on several external text files for its operation. These files are expected to be in the `bin/Debug` directory.

-   `egitim_veriseti.txt`: The training dataset. Each line should contain the input values followed by the expected output value(s), separated by spaces or tabs.
-   `agirlik_gizli.txt`: Stores the weights connecting the input layer to the hidden layer after training.
-   `agirlik_cikis.txt`: Stores the weights connecting the hidden layer to the output layer after training.

---

## 🚀 How to Run

Follow these instructions to get the project running on your local machine.

### Prerequisites

-   **Visual Studio:** 2019 or 2022 with the ".NET desktop development" workload installed.
-   **.NET Framework:** Version 4.8 Developer Pack must be installed.

### Configuration & Setup

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/your-username/YSAP.git](https://github.com/your-username/YSAP.git)
    cd YSAP
    ```

2.  **Open in Visual Studio:**
    -   Launch Visual Studio.
    -   Open the `YSAP.sln` file.

3.  **Prepare the Data:**
    -   Ensure you have a `egitim_veriseti.txt` file in the `bin/Debug` folder of the project.
    -   The format of this file is critical. Each line represents a training sample. For example, if you have 2 inputs and 1 output, a line might look like: `0.5 0.8 0.3`.

4.  **Build the Project:**
    -   In the Visual Studio menu, select `Build` > `Build Solution` (or press `Ctrl+Shift+B`).

5.  **Run the Application:**
    -   Press `F5` or click the "Start" button in the toolbar to launch the application.
    -   Set your desired training parameters in the UI and click "Train". Once training is complete, you can use the "Test" functionality.

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome. Feel free to check the [issues page](https://github.com/your-username/YSAP/issues).

1.  **Fork** the Project.
2.  Create your Feature Branch (`git checkout -b feature/NewActivationFunction`).
3.  Commit your Changes (`git commit -m 'Add ReLU activation function'`).
4.  Push to the Branch (`git push origin feature/NewActivationFunction`).
5.  Open a **Pull Request**.
