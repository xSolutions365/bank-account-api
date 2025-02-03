#!/bin/bash

# URL of the API endpoint
URL="http://localhost:5000/api/BankAccount"

# Number of requests to perform
NUM_REQUESTS=1000

# Number of multiple requests to make at a time
CONCURRENCY=10

echo "Running load test on $URL with $NUM_REQUESTS requests and concurrency level of $CONCURRENCY"

# Run ApacheBench
ab -n $NUM_REQUESTS -c $CONCURRENCY $URL