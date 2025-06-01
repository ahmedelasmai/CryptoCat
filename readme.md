# **🐱 Crypto Cats**

### **A blockchain-powered, turn-based RPG where you capture, train, and battle unique feline NFTs!**

https://ahthu-kiaaa-aaaap-akpza-cai.icp0.io

---

## **📖 Project Description**

Crypto Cats combines the engaging gameplay of turn-based RPGs with the power of blockchain and NFT integration. Players can capture, train, and trade unique Crypto Cat NFTs while progressing through an exciting 2D battle system.

The combination of **blockchain randomness** and **NFT-based economy** ensures fair gameplay and real asset ownership that works seamlessly across platforms.
---

##✨ Key Features**

- **Turn-Based RPG Mechanics:**  
   Engage in strategic battles and train your Crypto Cats to become stronger.
  
- **Decentralized NFT System:**  
   Every Crypto Cat is a unique NFT minted on the **Internet Computer**, providing real ownership and interoperability across chains.

- **Blockchain-Backed Randomness:**  
   Battles, loot drops, and RNG mechanisms are built using tamper-proof randomness.

- **Level Progression:**  
   Gain XP through battles to level up your Crypto Cats, unlocking new abilities and generating rewards.

- **Censorship-Resistant Infrastructure:**  
   Decentralized hosting using the Internet Computer ensures reliability and scalability.

---

## **🛠️ Technologies Used**

![oaicite:6](https://github.com/ahmedelasmai/CryptoCat/blob/main/logos/motoko.png?raw=true)
![oaicite:6](https://github.com/ahmedelasmai/CryptoCat/blob/59de4ee35a3d8bf3e208392cc07336aaced16ef7/logos/internetcomputer.png?raw=true)





![oaicite:6](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)
![oaicite:6](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![oaicite:6](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)
![oaicite:6](https://img.shields.io/badge/JavaScript-323330?style=for-the-badge&logo=javascript&logoColor=F7DF1E)
![oaicite:6](https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)



| **Area**               | **Technology**                                                                           |
|-------------------------|------------------------------------------------------------------------------------------|
| **Blockchain Backend** | [Motoko](https://internetcomputer.org/docs/current/motoko/main/motoko-introduction)       |
| **Backend Services**   | [Django](https://www.djangoproject.com/)                                                 |
| **Game Logic & Design**| [Unity](https://unity.com/) (C#)                                                          |
| **Authentication**     | [Internet Identity](https://smartcontracts.org/docs/ic-identity-guide/what-is-ic-identity.html) |
| **Randomness**         | Internet Computer blockchain randomness                                                  |
| **NFTs**               | NFT minting and transactions on the Internet Computer                                     |

---

## **📂 Folder Structure**

Here's an overview of the file and folder structure in this repository:

```plaintext
CryptoCat/
│
├── Unity_ProjectFiles/              # Full Unity project files for the 2D game logic and environments
│   └── ...                          # All Unity source files, assets, scripts
│
├── main.mo                          # Main Motoko smart contract for the blockchain (Minting, randomness, etc.)
├── dfx.json                         # Internet Computer project configuration
├── LICENSE                          # License for the project
├── deploy.sh                        # Script for deploying blockchain components or contracts
├── commands.txt                     # Useful terminal commands used during development
├── UnityBuild/                      # Unity build files for deployment
│   └── ...                          # Prebuilt Unity game files (e.g., WebGL, desktop versions)
│
├── website/                         # Files for the decentralized website
│   └── ...                          # Frontend (HTML/CSS/JS, possibly linked to a React or similar framework)
│
├── node_modules/                    # Node.js dependencies (if a frontend or CLI framework is used)
├── runtemp.py                       # Temporary Python file (possibly for data migration or debugging tasks)
├── images/                          # Game-related images or screenshots
├── hackathon-2024-october.zip       # Development archives for submission
├── CHANGELOG.md                     # Tracks the version history and changes
├── nft_transfer_project_1.zip       # Archive related to NFT transfer tests or functionality
└── mops.toml                        # Motoko package manager configuration
```

---

## **🚀 How to Run the Project**

### **1. Clone the Repository**
```bash
git clone https://github.com/ahmedelasmai/CryptoCat.git
cd CryptoCat
```

---

### **2. Blockchain Setup**
1. Start `dfx` to initiate the local Internet Computer environment:
   ```bash
   dfx start
   ```
3. Deploy the Motoko canisters (smart contracts):
   ```bash
   dfx deploy
   ```

---

### **3. Backend Setup**
1. Navigate to the `backend/` folder (if applicable for Django backend).
2. Create a virtual environment and install dependencies:
   ```bash
   python3 -m venv venv
   source venv/bin/activate
   pip install -r requirements.txt
   ```
3. Run the Django server:
   ```bash
   python manage.py runserver
   ```

---

### **4. Unity Game Client**
1. Open the `Unity_ProjectFiles/` folder using **Unity Hub**.
2. Build the game for your platform (WebGL, PC, or Mobile):
   - Go to `File > Build Settings` and select your target platform.
3. Alternatively, run the game in Unity Editor for testing.

---

### **5. Frontend Website**
1. Navigate to the `website/` folder.
2. Install dependencies (if using Node.js and a frontend framework like React):
   ```bash
   npm install
   npm run build
   ```
3. Serve the website locally:
   ```bash
   npm start
   ```

---
