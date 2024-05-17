export class TreeNodee {
  label: string;
  children?: TreeNodee[];
  data?: any;

  constructor(label: string, children?: TreeNodee[], data?: any) {
    this.label = label;
    this.children = children;
    this.data = data;
  }
}
