# Updated list of 10 unique addresses
addresses = [
    "http://be2us-64aaa-aaaaa-qaabq-cai.localhost:4943/7%20no%20backround.png",
    "http://be2us-64aaa-aaaaa-qaabq-cai.localhost:4943/8%20no%20backround.png",
    "http://be2us-64aaa-aaaaa-qaabq-cai.localhost:4943/9%20no%20backround.png",
    "http://be2us-64aaa-aaaaa-qaabq-cai.localhost:4943/10%20no%20backround.png",
    "http://be2us-64aaa-aaaaa-qaabq-cai.localhost:4943/11%20no%20backround.png",
    "http://be2us-64aaa-aaaaa-qaabq-cai.localhost:4943/12%20no%20backround.png",
    "http://be2us-64aaa-aaaaa-qaabq-cai.localhost:4943/13%20no%20backround.png",
    "http://be2us-64aaa-aaaaa-qaabq-cai.localhost:4943/14%20no%20backround.png",
    "http://be2us-64aaa-aaaaa-qaabq-cai.localhost:4943/15%20no%20backround.png",
    "http://be2us-64aaa-aaaaa-qaabq-cai.localhost:4943/16%20no%20backround.png",
]

# Repeat addresses to reach a total of 1000 unique URLs
expanded_addresses = (addresses * (1000 // len(addresses) + 1))[:1000]

# Open the commands.txt file to write all 10 commands
with open("commands.txt", "w") as file:
    # Loop to create 10 separate commands with 100 NFT records each
    for batch_num in range(10):
        # Start building the command for the current batch
        start_id = batch_num * 100
        end_id = start_id + 100
        command = 'dfx canister call icrc7 icrcX_mint "(\n  vec {'

        # Generate each NFT record for this batch
        for token_id in range(start_id, end_id):
            url = expanded_addresses[token_id]
            nft_record = f"""
    record {{
      token_id = {token_id} : nat;
      owner = opt record {{ owner = principal \\"$ICRC7_CANISTER\\"; subaccount = null; }};
      metadata = variant {{
        Class = vec {{
          record {{
            value = variant {{
              Text = \\"{url}\\"
            }};
            name = \\"icrc7:metadata:uri:image\\";
            immutable = true;
          }};
        }}
      }};
      memo = opt blob \\"\\00\\01\\";
      override = true;
      created_at_time = null;
    }};"""
            command += nft_record

        # Close the command structure for this batch
        command += '  }\n)"\n\n'

        # Write this command to commands.txt
        file.write(command)

print("Commands written to commands.txt")
