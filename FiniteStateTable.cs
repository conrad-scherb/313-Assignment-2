using System;
using System.Collections.Generic;

namespace _313_Assignment_2 {

    // A struct representing the contents of a cell on the finite state table
    public struct cell_FST {
        public int nextState;
        public List<Action> actions;

        public cell_FST(int nextState, List<Action> actions) {
            this.nextState = nextState;
            this.actions = actions;
        } 

        public void SetCellActions(List<Action> actions) {
            this.actions = actions;
        }

        public void SetCellNextState(int nextState) {
            this.nextState = nextState;
        }
    }

    public class FiniteStateTable {
        private List<List<cell_FST?>> FST;
        private int currentState;

        public FiniteStateTable(int startState, int maxEvents, int maxStates) {
            FST = new List<List<cell_FST?>>();
            for (int i = 0;  i < maxEvents; i++) {
                List<cell_FST?> stateRow = new List<cell_FST?>();
                for (int j = 0; j < maxEvents; j++) {
                    stateRow.Add(null);
                }
                FST.Add(stateRow);
            }

            currentState = startState;
        }

        public void SetNextState(int state, int onEvent, int newState) {
            FST[onEvent][state]?.SetCellNextState(newState);
        }

        public void SetActions(int state, int onEvent, List<Action> newActions) {
            FST[onEvent][state]?.SetCellActions(newActions);
        }

        public void FillCell(int state, int onEvent, int newState, List<Action> newActions) {
            FST[onEvent][state] = new cell_FST(newState, newActions);
        }

        public bool ExecuteEvent(int onEvent) {
            // Check if this action is registered (i.e. has a cell_FST at that table location)
            if (FST[onEvent][currentState] != null) {
                // Execute each action involved with this state change
                foreach (Action action in FST[onEvent][currentState].Value.actions) {
                    action();
                }
                currentState = FST[onEvent][currentState].Value.nextState;
                return true;
            } else {
                // No state change occured or action executed
                return false;
            }
        }

        public int? GetNextState(int state, int onEvent) {
            return FST[onEvent][currentState]?.nextState;
        }

        public List<Action> GetActions(int state, int onEvent) {
            return FST[onEvent][state]?.actions;
        }

        public int getCurrentState() {
            return currentState;
        }
    }
}