import requests

# Replace with your OpenRouter API key
API_KEY = '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'
API_URL = 'https://openrouter.ai/api/v1/chat/completions'

# Define the headers for the API request
headers = {
    'Authorization': f'Bearer {API_KEY}',
    'Content-Type': 'application/json'
}

# Define the request payload (data)
data = {
    "model": "deepseek/deepseek-chat:free",
    "messages": [{"role": "user", "content": "Wat is de laatste vraag die ik jou vroeg?"}]
}

# Send the POST request to the DeepSeek API
response = requests.post(API_URL, json=data, headers=headers)

# Check if the request was successful
if response.status_code == 200:
    print(response.json()["choices"][0]["message"]["content"])
else:
    print("Failed to fetch data from API. Status Code:", response.status_code)
