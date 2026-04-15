# ace-agentic-compliance-engine
AI-powered document extraction, verification, and human review platform
# ACE — Agentic Compliance Engine

ACE is a microservice-based platform for ingesting enterprise documents, extracting structured compliance data with AI agents, verifying the results against source evidence, and enabling human-in-the-loop review.

## Why this project
This project demonstrates:
- .NET Clean Architecture for enterprise workflows
- Python AI services for extraction and verification
- React TypeScript frontend for operational review
- PostgreSQL and SQL Server for realistic enterprise persistence
- Docker Compose and Kubernetes manifests for deployment readiness

## Core Features
- Document upload and processing
- AI-based structured extraction
- Evidence-backed verification
- Confidence scoring
- Human review workflow
- Audit trail
- Multi-service architecture

## Planned Architecture
- API Gateway: ASP.NET Core (.NET 8)
- AI Worker: FastAPI + Python
- Frontend: React + TypeScript
- Databases: PostgreSQL + SQL Server

## MVP Workflow
1. Upload a document
2. Process it with the AI worker
3. Extract structured fields
4. Verify against evidence
5. Review and approve results

## Repository Structure
```text
services/
  api-gateway-dotnet/
  ai-worker-python/
  web-react/

docs/
infra/
shared/
scripts/
