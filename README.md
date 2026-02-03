# 🐌 Snail-Shooter: The Single-Class Challenge

A fast-paced, 2-player arcade shooter developed as a technical challenge to implement a complete game engine within a **single C# class**. Built using the **Windows Forms (WinForms)** framework, this project demonstrates high-level state management and event-driven programming.



## 🎯 The Challenge
The goal was to build a fully functional game—including physics, UI, and level progression—without using external libraries or multiple files. This required deep control over the **WinForms Lifecycle** and manual synchronization of multiple asynchronous timers.

## 🚀 Key Features
* **Dual-Player Combat:** Local multiplayer with independent controls (WASD vs. Arrow Keys).
* **Real-Time Physics:** Custom collision detection using the `.Bounds.IntersectsWith()` logic.
* **Level Progression:** 3-stage difficulty system that scales speed and introduces environmental hazards (Snail/Wind).
* **Profile Management:** Dynamic player profiles with customizable colors and gender-based UI themes.
* **State Persistence:** In-memory tracking of scores, health (Progress Bars), and game history.

## 🛠️ Technical Breakdown
* **The Heartbeat:** Managed via 6 parallel `System.Windows.Forms.Timer` objects, each handling specific tasks like bullet velocity, movement polling, and the level clock.
* **Input Polling:** Uses `KeyDown` and `KeyUp` events with boolean flags to prevent the "stuttering" effect common in basic WinForms movement.
* **Collision Engine:** Manual logic to detect intersections between bullets and player hitboxes, triggering health depletion and level transitions.



---

## 🛡️ Senior Mentor Perspective
Even in a single-file project, this code demonstrates professional concepts:
* **State Machines:** Using `Lcounter` and `start` flags to control the "Flow" of the application (Menu -> Play -> Pause).
* **UI/UX Feedback:** Dynamic color changes based
