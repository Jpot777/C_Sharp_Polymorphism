### Project Name : Polymorphism
- This project teaches Programmers how to use Polymorphism in Unity.

### Project Structure
- Cube(Pc), Sphere(Monster), Capsule(Boss)
- Script :
CharacterManager.cs => The character(Pc, Monster, Boss) behaves according to the keyboard response. (M, A, C, I)
Unit.cs => Top-Level parent script.(Pc, Monster, Boss)
          It is a script that inherits object color and attack function.

### How to use
- Keyboard M : Execute their own actions. (Move, Rotate)
- Keyboard A : Execute 'Attack()' Function. Can see their own attack actions.
- Keyboard C : Change type => 1. Cube(Pc)  /  2. Sphere(Monster) /  3. Capsule(Boss)
- Keyboard I : Dynamically spawn according to current type.
