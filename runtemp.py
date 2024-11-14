import subprocess

# Read the commands from commands.txt
with open("commands.txt", "r") as file:
    # Split the file content by double newline to separate each command
    commands = file.read().strip().split("\n\n")

# print(commands[0])
# print("e")
# print(commands[1])
# # Execute each command separately
for i, command in enumerate(commands):
    print(f"Running command {i+1}/{len(commands)}")
    result = subprocess.run(command, shell=True, capture_output=True, text=True)
    
    # Check for errors and print output
    if result.returncode != 0:
        print(f"Error in command {i+1}: {result.stderr}")
    else:
        print(f"Output of command {i+1}:", result.stdout)
