# Monolish and Microservices

## Monolish
###  One application that does a lot of things
- Complicated logic
- Hard to iterate
- Hard for teamwork

### If you break the components down
- Bound by initial technology, later hard to change
- Easy to break things, especially some common code
- Traffic spikes, not easy to scale
- To modify a component a whole deployment is required - codebase is large
- Performance issue will take it down entirely

## Microservices
- Break system into individual components (logic, data, teamwork)
- Service needs to talk with each other.
- Scaling is also independent
- Cons: More latency, possible network failure (need extra logic for retry logic), backward compatibility, universal log system (additional cost), service discovery, configuration management system and auto scaling.
