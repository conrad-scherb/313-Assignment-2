namespace _313_Assignment_2 {

    // A struct representing the contents of a cell on the finite state table
    public struct cell_FST {
        public int nextState;
        public List<Action> actions;

        public cell_FST() {
            nextState = null;
            actions = null;
        }
    }

    public class FiniteStateTable {
        private List<List<cell_FST>> FST;
        private int startingState;

        public FiniteStateTable(int startState, int maxEvents, int maxStates) {
            FST = new List<>();
            for (int i = 0;  i < maxEvents; i++) {
                List<cell_FST> stateRow = List<>();
                for (int j = 0; j < max; j++) {
                    stateRow.add(new cell_FST());
                }
                FST.add(stateRow);
            }

            startingState = startState;
        }

        public SetNextState(int state, int onEvent, int newState) {
            FST[onEvent][state].nextState = newState;
        }

        public SetActions(int state, int onEvent, List<Action> newActions) {
            FST[onEvent][state].actions = newActions;
        }

        public int GetNextState(int state, int onEvent) {
            return FST[onEvent][state].nextState;
        }

        public int GetActions(int state, int onEvent) {
            return FST[onEvent][state].actions;
        }
    }
}